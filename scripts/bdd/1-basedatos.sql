
print '****************************************'
print 'CREANDO LA BASE DE DATOS'
create database bdd_bpichincha1
go
print 'Finalizado con exito'
print '****************************************'
go
print ' '
print 'usamos la nueva base '
go
USE [bdd_bpichincha1]
GO
print '****************************************'
print 'Creando las tablas'
print ' '
print '  [x]  Tabla Persona'
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

if exists (select 1  from sysobjects where id = OBJECT_ID('bp_persona'))
begin
    DROP TABLE [dbo].[bp_persona];
end

GO
CREATE TABLE [dbo].[bp_persona] (
    [id_persona]             INT IDENTITY (1, 1) NOT NULL,
    [nombre_persona]         VARCHAR (50)  NULL,
    [genero_persona]         CHAR (1)      NULL,
    [edad_persona]           SMALLINT      NULL,
    [identificacion_persona] VARCHAR (13)  NULL,
    [direccion_persona]      VARCHAR (100) NULL,
    [telefono_persona]       VARCHAR (10)  NULL
);
go
print 'Finalizado con exito'
go

print '  [x]  Tabla Cliente'
USE [bdd_bpichincha1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists (select 1  from sysobjects where id = OBJECT_ID('bp_cliente'))
begin
    DROP TABLE [dbo].[bp_cliente];
end

GO
CREATE TABLE [dbo].[bp_cliente] (
    [id_cliente]    INT           IDENTITY (1, 1) NOT NULL,
    [id_persona]    INT           NOT NULL,
    [clave_cliente] VARCHAR (256) NOT NULL,
    [estado]        CHAR (1)      NOT NULL
);

go
print 'Finalizado con exito'
go


print '  [x]  Tabla Cuenta'
go

USE [bdd_bpichincha1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists (select 1  from sysobjects where id = OBJECT_ID('bp_cuenta'))
begin
    DROP TABLE [dbo].[bp_cuenta];
end

GO
CREATE TABLE [dbo].[bp_cuenta] (
    [id_cuenta]     INT          IDENTITY (1, 1) NOT NULL,
    [numero_cuenta] VARCHAR (12) NOT NULL,
    [tipo_cuenta]   CHAR (3)     NULL,
    [saldo_inicial] MONEY        NOT NULL,
    [estado]        CHAR (1)     NOT NULL
);
go
print 'Finalizado con exito'
go


print '  [x]  Tabla Cliente Cuenta'
go
USE [bdd_bpichincha1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists (select 1  from sysobjects where id = OBJECT_ID('bp_cliente_cuenta'))
begin
    DROP TABLE [dbo].[bp_cliente_cuenta];
end

GO
CREATE TABLE [dbo].[bp_cliente_cuenta] (
    [id_cliente_cuenta] INT           IDENTITY (1, 1) NOT NULL,
    [id_cliente]        INT           NOT NULL,
    [id_cuenta]         INT           NOT NULL,
    [clave_cliente]     VARCHAR (256) NOT NULL,
    [estado]            CHAR (1)      NOT NULL
);

go
print 'Finalizado con exito'
go


print '  [x]  Tabla Movimiento'
go
USE [bdd_bpichincha1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists (select 1  from sysobjects where id = OBJECT_ID('bp_movimiento'))
begin
    DROP TABLE [dbo].[bp_movimiento];
end

GO
CREATE TABLE [dbo].[bp_movimiento] (
    [id_movimiento]    INT         IDENTITY (1, 1) NOT NULL,
    [id_cuenta]        INT         NOT NULL,
    [fecha_movimiento] DATETIME    NOT NULL,
    [tipo_movimiento]  VARCHAR (4) NOT NULL,
    [valor_movimiento] MONEY       NOT NULL,
    [saldo_cuenta]     MONEY       NOT NULL
);
go
print 'Finalizado con exito'
go
