# 🗄️ Guia de Migração para Base de Dados

## ⚠️ IMPORTANTE: Métodos que você DEVE MANTER

Os métodos que criei na classe `Empresa.cs` **SIM, serão utilizados com a Base de Dados!**

Estes métodos são **PERMANENTES** e devem ficar no código:

```csharp
// ✅ MANTER - Estes métodos são úteis SEMPRE (com ou sem BD)

// Métodos para Diretores
public List<Diretor> ObterDiretores()
public Diretor BuscarDiretorPorId(int id)
public bool RemoverDiretorPorId(int id)

// Métodos para Secretárias
public List<Secretaria> ObterSecretarias()
public Secretaria BuscarSecretariaPorId(int id)
public bool RemoverSecretariaPorId(int id)
public List<Secretaria> FiltrarSecretariasPorArea(string area)
```

### 💡 Por que MANTER estes métodos?

1. **Abstração**: Seus formulários não precisam saber se os dados vêm da memória ou BD
2. **Reutilização**: Você já tem formadores com métodos similares
3. **Facilidade**: Quando migrar para BD, só muda a IMPLEMENTAÇÃO interna, não a chamada
4. **Padrão Repository**: É uma boa prática de arquitetura

---

## 🔴 O que REMOVER quando implementar BD

### ❌ 1. No arquivo `Program.cs`

**REMOVER/COMENTAR estas linhas:**

```csharp
// ❌ COMENTAR ou DELETAR esta linha:
CarregarDadosTeste(empresa);

// ❌ DELETAR todo este método:
private static void CarregarDadosTeste(Empresa empresa)
{
    // ... todo o conteúdo deste método
}
```

**ADICIONAR no lugar:**

```csharp
// ✅ ADICIONAR quando tiver BD:
CarregarDadosDaBaseDeDados(empresa);
```

---

## 🔄 Como a Migração Funcionará

### ANTES (Dados em Memória - Atual)

```csharp
// Program.cs
var empresa = new Empresa("Escola ADOSMELHORES");
CarregarDadosTeste(empresa); // ← Preenche lista em memória

// Nos formulários
var diretores = empresa.ObterDiretores(); // ← Busca da lista em memória
```

### DEPOIS (Com Base de Dados)

```csharp
// Program.cs
var empresa = new Empresa("Escola ADOSMELHORES");
CarregarDadosDaBaseDeDados(empresa); // ← Busca da BD e preenche em memória
// OU deixa vazio e carrega sob demanda

// Nos formulários - CÓDIGO PERMANECE IGUAL!
var diretores = empresa.ObterDiretores(); // ← Busca da lista em memória (que veio da BD)
```

**OU MELHOR - Carregamento Sob Demanda:**

```csharp
// Empresa.cs - MODIFICAÇÃO FUTURA
public List<Diretor> ObterDiretores()
{
    // ANTES: return funcionarios.OfType<Diretor>().ToList();
    
    // DEPOIS (com BD):
    if (funcionarios.Count == 0)
    {
        CarregarFuncionariosDaBaseDeDados(); // Carrega sob demanda
    }
    return funcionarios.OfType<Diretor>().ToList();
}
```

---

## 📋 Checklist de Migração para BD

### Fase 1: Preparação
- [ ] Criar schema da base de dados
- [ ] Criar tabelas (Funcionarios, Diretores, Secretarias)
- [ ] Instalar pacotes NuGet (Entity Framework ou ADO.NET)
- [ ] Criar classe de conexão à BD

### Fase 2: Remover Dados de Teste
- [ ] No `Program.cs`, **comentar** linha: `CarregarDadosTeste(empresa);`
- [ ] No `Program.cs`, **deletar** método completo: `CarregarDadosTeste()`
- [ ] **MANTER** todos os métodos em `Empresa.cs` (ObterDiretores, etc.)

### Fase 3: Implementar Camada de Dados
- [ ] Criar classe `FuncionarioRepository` ou `DatabaseService`
- [ ] Implementar métodos CRUD na camada de dados
- [ ] Modificar `Empresa.cs` para usar a camada de dados

### Fase 4: Atualizar Empresa.cs (Opcional)
- [ ] Adicionar dependência de `DatabaseService`
- [ ] Modificar métodos para buscar da BD quando necessário

---

## 🎯 Exemplo de Implementação Futura

### Opção 1: Carregar Tudo na Inicialização (Mais Simples)

```csharp
// Program.cs
var empresa = new Empresa("Escola ADOSMELHORES");
var dbService = new DatabaseService();
dbService.CarregarTodosFuncionarios(empresa); // Preenche a lista
Application.Run(new Forms.FormLogin(empresa));

// Empresa.cs - NENHUMA ALTERAÇÃO NECESSÁRIA!
// Os métodos ObterDiretores(), etc. continuam funcionando
```

### Opção 2: Lazy Loading (Mais Avançado)

```csharp
// Empresa.cs - MODIFICAÇÃO FUTURA
private DatabaseService _dbService;

public Empresa(string nome, DatabaseService dbService = null)
{
    Nome = nome;
    funcionarios = new List<Funcionario>();
    _dbService = dbService;
}

public List<Diretor> ObterDiretores()
{
    // Se tiver DB service e lista vazia, carrega da BD
    if (_dbService != null && funcionarios.Count == 0)
    {
        var funcionariosDaBD = _dbService.ObterTodosFuncionarios();
        foreach (var f in funcionariosDaBD)
        {
            funcionarios.Add(f);
        }
    }
    
    return funcionarios.OfType<Diretor>().ToList();
}
```

### Opção 3: Repository Pattern (Mais Profissional)

```csharp
// Nova classe: FuncionarioRepository.cs
public class FuncionarioRepository
{
    private string connectionString;
    
    public List<Diretor> ObterDiretores()
    {
        // Consulta SQL ou Entity Framework
        using (var connection = new SqlConnection(connectionString))
        {
            var query = "SELECT * FROM Diretores";
            // ... retorna lista de diretores da BD
        }
    }
    
    public Diretor BuscarDiretorPorId(int id)
    {
        // Consulta SQL específica
    }
}

// Empresa.cs - MODIFICAÇÃO FUTURA
private FuncionarioRepository _repository;

public List<Diretor> ObterDiretores()
{
    return _repository.ObterDiretores(); // Delega para repository
}
```

---

## 📊 Comparação: O Que Muda vs O Que Fica

### ❌ O QUE VAI MUDAR (Apenas implementação interna)

| Localização | O Que Muda |
|-------------|------------|
| `Program.cs` | Remover `CarregarDadosTeste()` |
| `Program.cs` | Adicionar inicialização de BD |
| `Empresa.cs` | Adicionar `DatabaseService` (opcional) |
| `Empresa.cs` | Métodos podem buscar da BD internamente |

### ✅ O QUE NÃO VAI MUDAR (Interface pública)

| Localização | O Que Permanece Igual |
|-------------|----------------------|
| Formulários | `empresa.ObterDiretores()` - mesma chamada |
| Formulários | `empresa.BuscarDiretorPorId(id)` - mesma chamada |
| Formulários | `empresa.ObterSecretarias()` - mesma chamada |
| `Empresa.cs` | Assinatura dos métodos públicos |

---

## 💻 Exemplo Prático de Migração

### CÓDIGO ATUAL (Sem BD)

```csharp
// FormGerirDiretores.cs
private void CarregarDiretores()
{
    var diretores = empresa.ObterDiretores();
    dataGridView1.DataSource = diretores;
}
```

### CÓDIGO FUTURO (Com BD)

```csharp
// FormGerirDiretores.cs - EXATAMENTE IGUAL!
private void CarregarDiretores()
{
    var diretores = empresa.ObterDiretores(); // ← Mesma linha!
    dataGridView1.DataSource = diretores;
}

// A DIFERENÇA está APENAS na implementação interna de ObterDiretores()
// que agora busca da BD ao invés da lista em memória
```

---

## 🚀 Recomendação de Arquitetura Futura

Quando implementar a BD, sugiro esta estrutura:

```
ADOSMELHORES/
├── Modelos/
│   ├── Funcionario.cs       ✅ MANTER
│   ├── Diretor.cs           ✅ MANTER
│   ├── Secretaria.cs        ✅ MANTER
│   └── Empresa.cs           ✅ MANTER (modificar internamente)
├── Data/                    ⭐ NOVO
│   ├── DatabaseContext.cs   ⭐ ADICIONAR
│   └── FuncionarioRepository.cs  ⭐ ADICIONAR
├── Forms/                   ✅ MANTER (sem alterações)
└── Program.cs               🔄 MODIFICAR (remover CarregarDadosTeste)
```

---

## ✅ Resumo Executivo

### O Que Você DEVE Fazer Agora:
1. ✅ **USE os métodos** que criei - eles são permanentes
2. ✅ **Desenvolva seus formulários** usando estes métodos
3. ✅ **Não se preocupe** - a migração será simples

### O Que Você VAI Fazer no Futuro:
1. 🔄 **Remover** apenas o método `CarregarDadosTeste()` do Program.cs
2. 🔄 **Adicionar** camada de acesso à BD
3. 🔄 **Opcionalmente modificar** implementação interna dos métodos
4. ✅ **Formulários permanecem iguais** - nenhuma alteração necessária

---

## 🎓 Vantagens desta Arquitetura

✅ **Separação de Responsabilidades** - Empresa.cs não precisa saber sobre BD
✅ **Facilidade de Teste** - Pode testar com dados em memória
✅ **Migração Suave** - Formulários não precisam ser alterados
✅ **Flexibilidade** - Pode trocar BD sem quebrar código
✅ **Código Limpo** - Cada classe tem uma responsabilidade clara

---

## 📞 Dúvidas Frequentes

**P: Os métodos ObterDiretores() vão funcionar com BD?**
R: ✅ SIM! Podem continuar retornando de uma lista em memória (que foi carregada da BD) ou você pode modificá-los para buscar diretamente da BD.

**P: Preciso reescrever todos os formulários quando migrar?**
R: ❌ NÃO! Os formulários chamam os mesmos métodos, que continuarão funcionando.

**P: E se eu quiser Entity Framework?**
R: ✅ Perfeito! Os métodos da Empresa.cs podem usar um DbContext internamente.

**P: Posso fazer testes agora sem BD?**
R: ✅ SIM! É exatamente para isso que serve esta implementação.

---

## 🎯 Conclusão

**Os métodos são PERMANENTES e ÚTEIS!**

A única coisa temporária é o método `CarregarDadosTeste()` no `Program.cs`.

Continue desenvolvendo normalmente! 🚀
