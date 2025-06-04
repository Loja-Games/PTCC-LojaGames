drop database db_vxgames;
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
img_path varchar(500) default '/assets/image/icones/404.svg',
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
Img_path varchar(200),
Cargo_cli varchar (50) default'Cliente',
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
Cpf_cli varchar(11),
Cep varchar(8) not null,
Numero_residencia varchar(10) not null,
Uf_est char(2),
Endereco varchar(100) not null,
Complemento varchar(50),
primary key(Cep, Numero_residencia),
foreign key(Cep) references Tb_cep(Cep),
foreign key(Uf_est) references Tb_estado(Uf_est),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_carrinho(
Id_carrinho int auto_increment,
Id_pedido int,
Cpf_cli char(11) not null,
Id_prod int not null,
Id_pag int not null,
inforamacaoad_pag varchar(300) default 'Não informado',
quantidade int default '1',
preco_prod numeric(20,2) not null,
Data_pedido_car datetime,
Data_entrega_car datetime,
Tipo_entrega_car varchar(100),
Cep varchar(8),
Numero_residencia varchar(10),
primary key(id_carrinho),
foreign key(Cep, Numero_residencia) references Tb_endereco(Cep, Numero_residencia),
foreign key(Id_prod) references Tb_produto(Id_prod),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli),
foreign key(Id_pag) references Tb_pagamento(Id_pag)
);

update Tb_carrinho set quantidade=quantidade+1 where Id_carrinho=1;

select * from Tb_carrinho;
select * from Tb_pagamento;
insert into Tb_carrinho(Id_pedido, Cpf_cli, Id_prod, Id_pag, preco_prod, quantidade)
values (1, '00000000000', 2, 1, 3000, 1);


select * from tb_carrinho;

SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Id_pag=4,inforamacaoad_pag='Pagamento de Boleto Online', Data_pedido_car=curdate(), Data_entrega_car=DATE_ADD(CURDATE(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=0;SET SQL_SAFE_UPDATES = 1;

insert into Tb_carrinho(Id_pedido,Cpf_cli,Id_prod,Id_pag,preco_prod) values
(0,'00000000000',1,1,3000);

select * from Tb_pagamento;


/*
select max(Id_carrinho) as 'max' from Tb_carrinho;
*/

select max(Id_pedido) as 'max' from Tb_carrinho;

Select * from Tb_carrinho where Id_pedido='2';

select * from Tb_carrinho;

update Tb_usuario set Cargo_cli='ADMIN' where Cpf_cli='00000000000';

