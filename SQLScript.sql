create database ProjetoLojaGames;
use ProjetoLojaGames;
drop database ProjetoLojaGames;

create table Usuario(
IdUsuario int primary key auto_increment,
Usuario varchar (30) not null,
Senha varchar (50) not null,
Ativo bool default(true) not null

);

Create Table Cliente(
IdUsuario int,
CpfCli varchar(11) not null,
IdCli int auto_increment, 
EmailCli varchar (40) not null,
NomeCli varchar (50) not null,
primary key(CpfCli, IdCli)
);

Create Table Produto(
IdProduto int auto_increment primary key,
NomeProduto varchar (30),
DescProduto varchar (50),
PrecoProduto decimal (10,2),
DescontoProduto numeric(10.2)
);

select * from  Usuario;
select * from  Cliente;
select * from  Produto;
