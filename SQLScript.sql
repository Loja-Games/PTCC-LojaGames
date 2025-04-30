create database db_vxgames;
use db_vxgames;

create table Tb_produto(
Id_prod int auto_increment,
Nome_prod varchar(50),
Descricao_prod varchar(50),
ValorCusto_prod numeric(10,2),
ValorVenda_prod numeric(10,2),
Desconto_prod numeric(10,2),
Tipo_prod varchar(50),
Marca_prod varchar(50),
QuantidadeEstoque_prod int,
VendaDisponivel_prod bool default 1,
primary key(Id_prod)
);

create table Tb_pagamento(
Id_pag int auto_increment primary key,
descricao_pag varchar(100)
);

create table Tb_estado(
Uf_est char(2),
Nome_est varchar(50),
primary key(Uf_est)
);

create table Tb_cliente(
Cpf_cli char(11),
Nome_cli varchar(100) not null,
primary key(Cpf_cli)
);

create table Tb_email(
Id_Email int auto_increment,
Cpf_cli char(11) not null,
Email varchar(50) not null,
primary key(Id_Email),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_usuario(
Cpf_cli char(11) not null,
Usuario_cli varchar(50),
Senha_cli varchar(50) not null,
Cargo_cli varchar (50) default 'Cliente',
Ativo_cli bool default 1,
primary key(Usuario_cli),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_telefone(
Id_telefone int auto_increment,
Cpf_cli char(11) not null,
Telefone varchar(50) not null,
DD varchar(10) not null,
primary key(Id_telefone),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_cep(
Cep varchar(8) primary key,
Bairro varchar(100) not null,
Cidade varchar(100) not null
);

create table Tb_endereco(
Cep varchar(8) not null,
Numero_residencia varchar(10) not null,
Uf_est char(2),
Endereco varchar(100) not null,
Complemento varchar(50) not null,
primary key(Cep, Numero_residencia),
foreign key(Cep) references Tb_cep(Cep),
foreign key(Uf_est) references Tb_estado(Uf_est)
);

create table Tb_carrinho(
Id_carrinho int auto_increment,
Cpf_cli char(11) not null,
Id_prod int not null,
preco_prod numeric(20,2) not null,
Data_pedido_car date not null,
Data_entrega_car date not null,
Tipo_entrega_car varchar(100) not null,
Cep varchar(8) not null,
Numero_residencia varchar(10) not null,
primary key(id_carrinho),
foreign key(Cep, Numero_residencia) references Tb_endereco(Cep, Numero_residencia),
foreign key(Id_prod) references Tb_produto(Id_prod),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli)
);




