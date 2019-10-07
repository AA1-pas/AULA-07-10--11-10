
--2.5  - Vamos Listar em uma seleção de nossos funcionarios por ordem alfabetica
select * from Funcionarios order by Nome asc

--2.6  - Vamos listar em uma seleção de nossos produtos do mais caro para o mais barato
select * from Produtos order by Valor desc

--2.7  - Vamos listar em uma seleção de nossos pedidos por funcionario trazendo o nome do funcionario
select ped.Id as 'Id Pedido',fun.Nome as 'Funcionário',pro.Nome as 'Produto', ped.Quantidade from Pedidos ped 
							left join Produtos pro on pro.Id = ped.ProdutoId
							left join Funcionarios fun on fun.Id = ped.FuncionarioId
							order by fun.Nome asc

--2.8  - Vamos listar em uma seleção de nossos pedidos agrupando por funcionario os pedidos e somando sua respectiva quantidade de itens
select fun.Nome as 'Funcionário', sum(ped.Quantidade) as 'Qtd.Total'
							from Pedidos ped 
							left join Produtos pro on pro.Id = ped.ProdutoId
							left join Funcionarios fun on fun.Id = ped.FuncionarioId
							group by fun.nome
							order by fun.Nome asc

--2.9  - Vamos listar em uma seleção de nossos pedidos agrupando por funcionario os pedidos e somando seu valor total lembrando que o valor total e a a "quantidade * valor"
select fun.Nome as 'Funcionário', sum(ped.Quantidade*pro.Valor) as 'Valor Total'
							from Pedidos ped 
							left join Produtos pro on pro.Id = ped.ProdutoId
							left join Funcionarios fun on fun.Id = ped.FuncionarioId
							group by fun.nome
							order by fun.Nome asc

--2.10 - Vamos retornar em uma seleção nosso produto mais pedido dentro de nossa base de dados
select top 1 pro.Nome as 'Produto', sum(ped.Quantidade) as Qtd_Total
							from Pedidos ped 
							inner join Produtos pro on pro.Id = ped.ProdutoId
							group by pro.nome
							order by Qtd_Total desc

--2.11 - Vamos retornar em uma seleção o produto que gerou a maior receita dentro de nossa base de dados 
select top 1 pro.Nome as 'Produto', concat('R$ ',sum(ped.Quantidade*pro.Valor)) as 'Valor Total'
							from Pedidos ped 
							left join Produtos pro on pro.Id = ped.ProdutoId
							group by pro.nome
							order by sum(ped.Quantidade*pro.Valor) desc

--2.12 - Vamos retornar em uma seleção para o primeiro funcionario os produtos que ele não comprou de nosso mercado
select pro.Nome from Produtos pro
							where pro.Id not in (select ped.ProdutoId from Funcionarios fun 
							left join Pedidos ped on ped.FuncionarioId= fun.Id 
							where fun.Nome like '%Allan%') 

--2.13 - Vamos retornar em uma seleção os produtos ordenados pela ordem do mais comprado para o menos comprado
select pro.Nome as 'Produto', count(ped.Id) as 'Qtd.Total'
							from Pedidos ped 
							left join Produtos pro on pro.Id = ped.ProdutoId
							group by pro.nome
							order by count(ped.Id) desc
							
