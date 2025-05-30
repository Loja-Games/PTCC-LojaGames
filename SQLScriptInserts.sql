use db_vxgames;

INSERT INTO Tb_produto 
(Nome_prod, Descricao_prod, ValorCusto_prod, ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod, VendaDisponivel_prod, img_path) 
VALUES 
('PlayStation 5', 'Console de última geração', 4500.00, 4050.00, 10.00, 'Console', 'Sony', 15, 1, 'https://m.media-amazon.com/images/I/51VZErxKwkL._AC_UF1000,1000_QL80_.jpg'),
('Xbox Series X', 'Console com desempenho de ponta', 4300.00, 3870.00, 10.00, 'Console', 'Microsoft', 10, 1,'https://cms-assets.xboxservices.com/assets/bc/40/bc40fdf3-85a6-4c36-af92-dca2d36fc7e5.png?n=642227_Hero-Gallery-0_A1_857x676.png'),
('Placa de Vídeo RTX 3060', 'GPU para jogos', 2800.00, 2380.00, 15.00, 'Hardware', 'NVIDIA', 20, 1,'https://images.kabum.com.br/produtos/fotos/180539/placa-de-video-gigabyte-geforce-rtx-3060-gaming-oc-12g-12-gb-gddr6-rev-2-0-ray-tracing-gv-3060gaming_1626461646_g.jpg'),
('Processador Ryzen 7', 'Processador Octa-Core', 1800.00, 1530.00, 15.00, 'Hardware', 'AMD', 30, 1,'https://media.pichau.com.br/media/catalog/product/cache/2f958555330323e505eba7ce930bdf27/1/0/100-100000926wof.jpg'),
('Notebook Gamer', 'Alto desempenho para jogos', 5200.00, 4420.00, 15.00, 'Notebook', 'ASUS', 8, 1,'https://images.kabum.com.br/produtos/fotos/sync_mirakl/462294/xlarge/Notebook-Gamer-Acer-Nitro-5-Intel-Core-i5-11400h-4-50GHz-8GB-GTX-1650-SSD-512GB-Tela-15-6-144Hz-Windows-11-AN515-57-59AT_1744223446.jpg'),
('Teclado Mecânico', 'RGB com switches azuis', 250.00, 200.00, 20.00, 'Acessórios', 'Logitech', 50, 1,'https://static.mundomax.com.br/produtos/84138/100/1.webp'),
('Mouse Gamer G903', 'Alto DPI com RGB', 150.00, 120.00, 20.00, 'Acessórios', 'Logitech', 40, 1,'https://supricom.com/wp-content/uploads/2024/04/mouse-gamer-logitech-g903-hero-ligthspeed-wireless-rgb-black-910-005670.jpg'),
('Jogo God of War Ragnarok', 'Mídia física', 300.00, 255.00, 15.00, 'Midia Fisica', 'Sony', 25, 1,'https://i.zst.com.br/thumbs/12/20/2a/-1340719298.jpg'),
('Jogo Forza Horizon 5', 'Mídia digital', 250.00, 200.00, 20.00, 'Midia Digital', 'Microsoft', 30, 1,'https://down-br.img.susercontent.com/file/2cf48df41ad2d68719929499bcf4b26d'),
('Placa-Mãe B450', 'Compatível com Ryzen', 600.00, 480.00, 20.00, 'Hardware', 'ASUS', 18, 1,'https://www.fgtec.com.br/media/catalog/product/cache/6630b9e112ee13f7d501bef37f6e88ec/b/d/bd73b3cc597fff90293a71f91151d35e.jpeg');

insert into Tb_pagamento(descricao_pag) values
('sem forma de pagamento'),
('Cartao de Debito'),
('Cartao de Credito'),
('Boleto'),
('PIX'),
('Outro');

insert into Tb_cliente values('00000000000','Admin');
insert into Tb_usuario(Cpf_cli,Usuario_cli,Senha_cli,Cargo_cli) values
('00000000000','admin','admin','ADMIN');







select * from tb_produto;