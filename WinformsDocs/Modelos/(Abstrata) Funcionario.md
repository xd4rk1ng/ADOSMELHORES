Tem que ter:
- ID (int)
- Nome (string)
- Morada (string)
- Contacto (string)
- Data fim contrato (DateTime)
- Data registo criminal (DateTime)
- Salário (Decimal)

(Atributos adicionais)
- NIF - Para impedir reinserção do mesmo funcionário, usa-se o NIF. O sistema deve reconhecer no momento de registo que o NIF já está registado para um dado ID, e daí impedir duplicação do funcionário. Deve surgir um alerta e perguntar se pretende atualizar os dados pessoais.

Classes que herdam de **Funcionário**
[Diretor](Diretor.md)
[Secretaria](Secretaria.md)
[Coordenador](Coordenador.md)
[Formador](Formador.md)
