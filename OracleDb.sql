login:ENGSOFT
senha:Demonio

alter session set "_ORACLE_SCRIPT"=true; 

/* Drop All Tables */


/* CREATE TABLE COMMANDS */

CREATE TABLE Maquina (
	Id int IDENTITY(1,1)
	,Nome varchar(100)
	,PRIMARY KEY(Id)
)

CREATE TABLE Suprimento (
	Id int IDENTITY(1,1)
	,Nome varchar(100)
	,PesoInicial int
	,PesoAtual int
	,Tipo varchar(20)
	,Cor varchar(30)
	,Status int
	,PRIMARY KEY(Id)
)

CREATE TABLE Cliente (
	Cpf varchar(11) NOT NULL
	,Endereco varchar(100)
    ,Nome varchar(100) NOT NULL
    ,TelCel varchar(13)
    ,TelRes varchar(12) NOT NULL
    ,Email varchar(50) NOT NULL
    ,PRIMARY KEY(Cpf)
)

CREATE TABLE Pedido(
	Id int IDENTITY(1,1)
	,Identificador varchar(200) NOT NULL
	,IdCliente varchar(11) NOT NULL
	,Status int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdCliente)	REFERENCES Cliente(Cpf)
)

CREATE TABLE Item (
	Id int IDENTITY(1,1)
	,Nome varchar(100)
	,Qualidade int NOT NULL
	,Resistencia int NOT NULL
	,Arquivo varchar(200)
	,Quantidade int NOT NULL
	,IdPedido int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdPedido)	REFERENCES Pedido(Id)
)

CREATE TABLE Fabricacao (
	Id int IDENTITY(1,1)
	,IdMaquina int NOT NULL
	,IdPedido int NOT NULL
	,IdSuprimento int NOT NULL
	,Status int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdMaquina)	REFERENCES Maquina(Id)
	,FOREIGN KEY(IdPedido)	REFERENCES Pedido(Id)
	,FOREIGN KEY(IdSuprimento)	REFERENCES Suprimento(Id)
)

CREATE TABLE Estoque (
	Id int IDENTITY(1,1)
	,IdFabricacao int NOT NULL
	,IdPedido int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdFabricacao)	REFERENCES Fabricacao(Id)
	,FOREIGN KEY(IdPedido)	REFERENCES Pedido(Id)
)


CREATE TABLE ItensFabricacao (
	Id int IDENTITY(1,1)
	,IdItem int NOT NULL
	,IdFabricacao int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdItem)	REFERENCES Item(Id)
	,FOREIGN KEY(IdFabricacao)	REFERENCES Fabricacao(Id)
)

CREATE TABLE Login (
	Cpf varchar(11) NOT NULL
	,Email varchar(200) NOT NULL
    ,Nome varchar(100) NOT NULL
    ,Senha varchar(256)
    ,Ativo int NOT NULL
    ,Tipo varchar(50) NOT NULL
    ,PRIMARY KEY(Cpf)
 )

/* DUMMY DATA INSERTS */

