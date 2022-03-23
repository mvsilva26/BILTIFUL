use biltiful ;


create table Compra
(
Id              numeric(5,0) identity(1,1) not null,
Data_Compra      date not null DEFAULT GETDATE(),
Valor_Total      numeric(7,2) not null,
CNPJ_fornecedor varchar(14)  not null
constraint PK_Compra primary key(id),
constraint FK_Fornecedor_Compra foreign key(CNPJ_fornecedor) references Fornecedor(CNPJ)
);

select * from Compra

create table MPrima
(
Id              varchar(6) not null,
Nome            nvarchar(30) not null,
Ultima_Compra    date not null DEFAULT GETDATE(),
Data_Dadastro    date not null DEFAULT GETDATE(),
Situacao        char not null DEFAULT 'A'
constraint PK_MPrima primary key(Id)
);




select * from MPrima;


delete from MPrima;

create table fornecedor
(
CNPJ            varchar(14) not null,
Razao_Social     nvarchar(50) not null,
Data_Abertura    date not null,
Ultima_Compra    date not null DEFAULT GETDATE(),
Data_Dadastro    date not null DEFAULT GETDATE(),
Situacao        char not null DEFAULT 'A'
constraint PK_Fornecedor primary key(CNPJ)
);


select * from fornecedor;


create table ItemCompra
(
Quantidade      numeric(5,2) not null,
Valor_Unitario   numeric(5,2) not null,
Total_Item       numeric(6,2) not null,
Id_Compra_IC    numeric(5,0) not null,
Id_MPrima_IC    varchar(6) not null
constraint PK_Id_Compra_IC  primary key(Id_Compra_IC),
constraint FK_Id_Compra_IC  foreign key(Id_Compra_IC) references Compra(Id),
constraint FK_Id_MPrima_IC  foreign key(Id_MPrima_IC) references MPrima(Id)
);

select * from ItemCompra

create table Produto
(
Cod_Barras    numeric(12) IDENTITY(789661700001, 1) not null,
Nome            nvarchar(20) not null,
Valor_Venda      numeric(5,2) not null,
Ultima_Venda     date not null DEFAULT GETDATE(),
Data_Cadastro    date DEFAULT GETDATE(),
Situacao        char not null DEFAULT 'A'
constraint PK_Produto primary key (Cod_Barras)
);

select * from Produto;



create table Producao
(
Id                      numeric(5,0) identity not null,
Data_Producao            date not null DEFAULT GETDATE(),
Quantidade              numeric(5,2) not null,
Cod_Barras_Produto		numeric(12) not null
constraint PK_Producao primary key(Id),
constraint FK_Produto_Producao foreign key (Cod_Barras_Produto) references Produto(Cod_Barras)
);



create table Venda
(
Id          numeric(5,0) identity not null,
Data_Venda   date not null default getdate(),
Valor_Total  numeric(7,2) not null,
CPF_Cliente varchar(11) not null
constraint PK_Venda         primary key(Id),
constraint FK_Cliente_Venda foreign key(CPF_Cliente) references Cliente(CPF)
);



create table Cliente
(
CPF             varchar(11) not null,
Nome            nvarchar(50) not null,
Data_Nascimento  date not null,
Sexo            char not null,
Ultima_Compra    date not null default getdate(),
Data_Cadastro    date not null default getdate(),
Situacao        char not null default 'A',
constraint PK_Cliente primary key(CPF)
);




select * from Cliente


create table Bloqueado
(
CNPJ_Fornecedor varchar(14) not null
constraint PK_Bloqueado             primary key(CNPJ_Fornecedor),
constraint FK_Bloqueado_Fornecedor  foreign key (CNPJ_Fornecedor) references Fornecedor(CNPJ)
);


select * from Bloqueado


create table Risco
(
CPF_Cliente varchar(11) not null
constraint PK_Risco         primary key (CPF_Cliente),
constraint FK_Risco_Cliente foreign key (CPF_Cliente) references Cliente(CPF)
);

select * from Risco


create table ItemProducao
(
Id_Producao         numeric(5,0) not null,
Id_MPrima           numeric(4,0) not null,
Quantidade_MPrima    numeric(5,2) not null
constraint PK_Item_Producao primary key(Id_Producao),
constraint FK_Item_Producao foreign key(Id_Producao) references producao(Id)
);




create table Item_Venda
(
Id_Venda                numeric(5,0) not null,
Cod_Barras_Produto		numeric(12) not null,
Quantidade              numeric(3,0) not null,
Total_Item               numeric(6,2) not null,
Valor_Unitario           numeric(5,2) not null,
constraint FK_Venda_IV foreign key (Id_Venda) references Venda(Id),
constraint FK_Cod_Barras_IV foreign key (Cod_Barras_Produto) references Produto(Cod_Barras)
);



--------------------------------------------------------------------------------------------------------------



CREATE PROCEDURE Inserir_fornecedor
	@CNPJ varchar(14),
	@Razao_Social nvarchar(14),
	@Data_Abertura DATE
AS
BEGIN
	INSERT INTO fornecedor (CNPJ, Razao_Social, Data_Abertura)
	values (@CNPJ, @Razao_Social, @Data_Abertura)
END
--


GO
CREATE PROCEDURE Inserir_Cliente
	@CPF             varchar(11), 
	@Nome            nvarchar(50),
	@Data_Nascimento  date,
	@Sexo            char,
	@Situacao		char	
AS
BEGIN
	INSERT INTO Cliente (CPF, Nome, Data_Nascimento, Sexo, Situacao)
	VALUES (@CPF, @Nome, @Data_Nascimento, @Sexo, @Situacao)
END

--

CREATE PROCEDURE INSERIR_MPrima
	@Id              varchar(6),
	@Nome            nvarchar(30)
AS
BEGIN
	INSERT INTO MPrima (Id, Nome)
	VALUES (@Id, @Nome)
END

--




create PROCEDURE Inserir_Produto
	@Nome           nvarchar(20),
	@Valor_Venda    numeric(5,2)
AS 
BEGIN
	INSERT INTO Produto(Nome, Valor_Venda)
	VALUES (@Nome, @Valor_Venda)
END

--


GO
CREATE PROCEDURE Inserir_ItemCompra
	@Quantidade      numeric(5,2),
	@Valor_Unitario   numeric(5,2),
	@Total_Item       numeric(6,2)
AS
BEGIN
	INSERT INTO ItemCompra(Quantidade, Valor_Unitario, Total_Item)
	VALUES (@Quantidade, @Valor_Unitario, @Total_Item)
END

--


create proc Inserir_Compra
	@Valor_Total numeric(7,2),
	@CNPJ_fornecedor varchar(14)
as
begin
	insert into Compra (Valor_Total, CNPJ_fornecedor) values
	(@Valor_Total, @CNPJ_fornecedor);
end;
