login:ENGSOFT
senha:Demonio

alter session set "_ORACLE_SCRIPT"=true; 

/* Drop All Tables */


/* CREATE TABLE COMMANDS */

CREATE TABLE Maquina (
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,Nome varchar(100)
	,PRIMARY KEY(Id)
)

CREATE TABLE Suprimento (
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,Nome varchar(100)
	,PesoInicial int
	,PesoAtual int
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
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,Identificador varchar(200) NOT NULL
	,IdCliente varchar(11) NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdCliente)	REFERENCES Cliente(Cpf)
)

CREATE TABLE Item (
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
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
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,IdMaquina int NOT NULL
	,IdPedido int NOT NULL
	,IdSuprimento int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdMaquina)	REFERENCES Maquina(Id)
	,FOREIGN KEY(IdPedido)	REFERENCES Pedido(Id)
	,FOREIGN KEY(IdSuprimento)	REFERENCES Suprimento(Id)
)

CREATE TABLE Estoque (
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,IdFabricacao int NOT NULL
	,IdPedido int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdFabricacao)	REFERENCES Fabricacao(Id)
	,FOREIGN KEY(IdPedido)	REFERENCES Pedido(Id)
)


CREATE TABLE ItensFabricacao (
	Id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1)
	,IdItem int NOT NULL
	,IdFabricacao int NOT NULL
	,PRIMARY KEY(Id)
	,FOREIGN KEY(IdItem)	REFERENCES Item(Id)
	,FOREIGN KEY(IdFabricacao)	REFERENCES Fabricacao(Id)
)

CREATE TABLE Login (
	Cpf varchar(11) NOT NULL
    ,Nome varchar(100) NOT NULL
    ,Senha varchar(256)
    ,Tipo int NOT NULL
    ,PRIMARY KEY(Cpf)
 )

/* DUMMY DATA INSERTS */

