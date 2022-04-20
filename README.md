# Velha

create table Player (
	idPlayer int identity(1,1),
	userName VARCHAR(50),
	senha VARCHAR(50),
	rankingNormal INT,
	rankingSuper INT,
	PRIMARY KEY (idPlayer)

);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('mtasseler0', 'J6bxU5N8pVd', 394, 302);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('ronge1', '3Ir7Q2', 912, 313);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('mspridgen2', 'R3lvCiBF9J', 557, 269);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('faylen3', '7tEAEKP', 599, 935);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('nshapcott4', 'X2G1v9X', 683, 452);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('cnolan5', 'wrKNkUiY2C', 808, 789);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('lstyan6', '9LuWe1JFZ', 194, 542);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('dsaich7', 'gTM2JbktuHL', 391, 433);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('hasbury8', 'YM6ljJh4g', 575, 455);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('pdollin9', 'i55KRwBnZb', 715, 753);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('cjoriota', 'TBFjup', 134, 778);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('dbidewelb', 'Grq371', 721, 599);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('wgullimanc', 'eaPTIAtMEjbn', 760, 278);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('ggladingd', 'uoXuFgAmgLx', 410, 642);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('dwiddicombee', 'kGiGBGH', 903, 338);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('jinottf', 'pkVNqTcGeK', 410, 497);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('egroocockg', '4iHNfJLXr', 371, 417);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('bromagosah', 'Z9zHs7MCbsw1', 411, 658);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('bdommerquei', '7JJDeqgo', 259, 771);
insert into Player (userName, senha, rankingNormal, rankingSuper) values ('scollumj', 'PjkW6LSVa', 347, 413);





create table Fila (
	idFila int identity(1,1),
	idPlayer INT,
	ModoJogo INT,
	PRIMARY KEY (idFila),
    FOREIGN KEY (idPlayer) REFERENCES Player(idPlayer)
);
insert into Fila (idPlayer, ModoJogo) values (1, 0);
insert into Fila (idPlayer, ModoJogo) values (2, 0);
insert into Fila (idPlayer, ModoJogo) values (3, 0);
insert into Fila (idPlayer, ModoJogo) values (4, 0);
insert into Fila (idPlayer, ModoJogo) values (5, 1);
insert into Fila (idPlayer, ModoJogo) values (6, 0);
insert into Fila (idPlayer, ModoJogo) values (7, 1);
insert into Fila (idPlayer, ModoJogo) values (8, 0);
insert into Fila (idPlayer, ModoJogo) values (9, 1);
insert into Fila (idPlayer, ModoJogo) values (10, 1);
insert into Fila (idPlayer, ModoJogo) values (11, 1);
insert into Fila (idPlayer, ModoJogo) values (12, 1);
insert into Fila (idPlayer, ModoJogo) values (13, 0);
insert into Fila (idPlayer, ModoJogo) values (14, 1);
insert into Fila (idPlayer, ModoJogo) values (15, 0);
insert into Fila (idPlayer, ModoJogo) values (16, 1);
insert into Fila (idPlayer, ModoJogo) values (17, 1);
insert into Fila (idPlayer, ModoJogo) values (18, 0);
insert into Fila (idPlayer, ModoJogo) values (19, 1);
insert into Fila (idPlayer, ModoJogo) values (20, 0);





create table Jogo (
	idJogo int identity(1,1),
	idUser1 INT,
	idUser2 INT,
	vencedor INT,
	ModoJogo INT,
	PRIMARY KEY (idJogo),
    FOREIGN KEY (idUser1) REFERENCES Player(idPlayer),
	FOREIGN KEY (idUser2) REFERENCES Player(idPlayer)
);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (1, 20, 1, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (2, 19, 2, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (3, 18, 3, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (4, 17, 4, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (5, 16, 5, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (6, 15, 6, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (7, 14, 7, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (8, 13, 8, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (9, 12, 9, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (10, 11, 10, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (11, 10, 11, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (12, 9, 12, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (13, 8, 13, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (14, 7, 14, 0);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (15, 6, 15, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (16, 5, 16, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (17, 4, 17, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (18, 3, 18, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (19, 2, 19, 1);
insert into Jogo (idUser1, idUser2, vencedor, ModoJogo) values (20, 1, 20, 1);





create table Jogada (
	idJogada int identity(1,1),
	idJogo INT,
	campo INT,
	subcampo INT,
	simbolo VARCHAR(1),
	PRIMARY KEY (idJogada),
    FOREIGN KEY (idJogo) REFERENCES Jogo(idJogo)
);
insert into Jogada (idJogo, campo, subcampo, simbolo) values (1, 7, 3, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (2, 6, 9, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (3, 5, 9, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (4, 4, 2, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (5, 2, 8, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (6, 4, 1, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (7, 6, 5, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (8, 8, 9, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (9, 7, 7, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (10, 2, 6, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (11, 8, 9, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (12, 9, 1, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (13, 3, 5, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (14, 8, 7, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (15, 5, 6, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (16, 2, 6, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (17, 7, 5, 'X');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (18, 2, 6, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (19, 5, 3, 'O');
insert into Jogada (idJogo, campo, subcampo, simbolo) values (20, 9, 5, 'O');
