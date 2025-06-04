
INSERT INTO Tb_produto 
(Nome_prod, Descricao_prod, ValorCusto_prod, ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod, VendaDisponivel_prod, img_path) 
VALUES
-- Smartphones
('Smartphone Microsoft', 'Lumia 220 com 4G, 64GB de Armazenamento e Tela HD', 3289.95, 3289.95, 0.00, 'Smartphone', 'Microsoft', 23, 1, '/assets/image/itens/FotoSmartFone.png'),
('Smartphone Positivo', 'Android 10, 64GB e Câmera 13MP', 2803.24, 2522.92, 10.00, 'Smartphone', 'Positivo', 29, 1, '/assets/image/itens/SmartphonePOSITIVO-4.png'),
('Smartphone Microsoft', 'Tela de 6.5", 128GB e desempenho aprimorado', 2415.80, 2415.80, 0.00, 'Smartphone', 'Microsoft', 28, 1, '/assets/image/itens/SmartphoneASUS-2.png'),
('Smartphone Positivo', 'Compacto com 32GB, ideal para uso diário', 732.64, 732.64, 0.00, 'Smartphone', 'Positivo', 31, 1, '/assets/image/itens/TabletPOSITIVO-2.png'),
('Smartphone Sony', 'Smartphone com qualidade de som premium e 128GB de armazenamento', 1971.71, 1774.54, 10.00, 'Smartphone', 'Sony', 19, 1, '/assets/image/itens/SonyProdutoremoto2.png'),

-- Computadores
('Computador Asus', 'Monitor LED 21", 8GB RAM e SSD 256GB', 2817.65, 2817.65, 0.00, 'Computador', 'Asus', 35, 1, '/assets/image/itens/ComputadorCompleto.png'),
('Computador Positivo', 'PC com gabinete slim, ideal para escritório, com SSD 240GB', 2327.33, 1861.86, 20.00, 'Computador', 'Positivo', 38, 1, '/assets/image/itens/ComputadorPOSITIVO-5.png'),
('Computador Intel', 'Intel Core i5, 8GB RAM, 500GB HD', 2517.84, 2517.84, 0.00, 'Computador', 'Intel', 30, 1, '/assets/image/itens/Intel Core i3.png'),
('Computador Asus', 'PC com monitor 24", 16GB RAM e placa de vídeo dedicada', 2994.53, 2545.35, 15.00, 'Computador', 'Asus', 33, 1, '/assets/image/itens/MonitorGamerASUS-5.png'),
('Computador Positivo', 'Computador com Windows 10 e 4GB RAM', 1845.27, 1845.27, 0.00, 'Computador', 'Positivo', 39, 1, '/assets/image/itens/KitCasaConectadaPOSITIVO-3.png'),

-- Acessórios
('Adaptador Logitech', 'Para dispositivos USB-C com entrada HDMI', 129.90, 129.90, 0.00, 'Acessório', 'Logitech', 50, 1, '/assets/image/itens/AdaptadorLOGITECH-3.png'),
('Fone de Ouvido', 'Com microfone, ideal para chamadas e música', 89.90, 149.90, 10.00, 'Acessório', 'Genérico', 100, 1, '/assets/image/itens/FoneAcessorio.png'),
('Mouse Logitech', 'Sem fio com design ergonômico e alta precisão', 79.90, 79.90, 0.00, 'Acessório', 'Logitech', 75, 1, '/assets/image/itens/MouseSemFioLOGITECH-2.png'),
('Teclado Logitech', 'Mecânico com retroiluminação RGB', 199.90, 199.90, 0.00, 'Acessório', 'Logitech', 60, 1, '/assets/image/itens/TecladoGamerLOGITECH-5.png'),
('Placa de Vídeo ASUS', 'RTX 3090 para jogos em 4K', 4999.90, 7999.90, 15.00, 'Acessório', 'ASUS', 20, 1, '/assets/image/itens/PlacaDeVideoASUS-4.png'),

-- Consoles (mantém o desconto)
('PlayStation 5', '1TB de armazenamento e controle sem fio', 4999.90, 5999.90, 10.00, 'Console', 'Sony', 40, 1, '/assets/image/itens/PlayStation 5.png'),
('Xbox Series X', '1TB de armazenamento e suporte a 4K', 4999.90, 5999.90, 10.00, 'Console', 'Microsoft', 45, 1, '/assets/image/itens/XboxSeriesX1.png'),
('Controle Xbox Elite', 'com botões personalizáveis e alta precisão', 499.90, 499.90, 0.00, 'Acessório', 'Microsoft', 50, 1, '/assets/image/itens/XboxControlerElite5.png'),

-- Softwares
('Pacote Windows e Office', 'Windows 11 Pro e Office 2021 para uso profissional', 799.90, 999.90, 15.00, 'Software', 'Microsoft', 100, 1, '/assets/image/itens/PacoteWindowsEOffice-5.png'),
('Windows 10', 'Windows 10 Home para uso doméstico', 199.90, 199.90, 0.00, 'Software', 'Microsoft', 200, 1, '/assets/image/itens/Window10-2.png'),
('Windows 11', 'Windows 11 Home com interface moderna', 249.90, 249.90, 0.00, 'Software', 'Microsoft', 150, 1, '/assets/image/itens/Window11-1.png');
