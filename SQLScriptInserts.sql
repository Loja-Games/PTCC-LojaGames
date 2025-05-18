use db_vxgames;

INSERT INTO Tb_produto 
(Nome_prod, Descricao_prod, ValorCusto_prod, ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod, VendaDisponivel_prod) 
VALUES 
('PlayStation 5', 'Console de última geração', 4500.00, 4050.00, 10.00, 'Console', 'Sony', 15, 1),
('Xbox Series X', 'Console com desempenho de ponta', 4300.00, 3870.00, 10.00, 'Console', 'Microsoft', 10, 1),
('Placa de Vídeo RTX 3060', 'GPU para jogos', 2800.00, 2380.00, 15.00, 'Hardware', 'NVIDIA', 20, 1),
('Processador Ryzen 7', 'Processador Octa-Core', 1800.00, 1530.00, 15.00, 'Hardware', 'AMD', 30, 1),
('Notebook Gamer', 'Alto desempenho para jogos', 5200.00, 4420.00, 15.00, 'Notebook', 'ASUS', 8, 1),
('Teclado Mecânico', 'RGB com switches azuis', 250.00, 200.00, 20.00, 'Acessórios', 'Logitech', 50, 1),
('Mouse Gamer', 'Alto DPI com RGB', 150.00, 120.00, 20.00, 'Acessórios', 'Logitech', 40, 1),
('Jogo God of War Ragnarok', 'Mídia física', 300.00, 255.00, 15.00, 'Midia Fisica', 'Sony', 25, 1),
('Jogo Forza Horizon 5', 'Mídia digital', 250.00, 200.00, 20.00, 'Midia Digital', 'Microsoft', 30, 1),
('Placa-Mãe B450', 'Compatível com Ryzen', 600.00, 480.00, 20.00, 'Hardware', 'ASUS', 18, 1);

select * from tb_produto;