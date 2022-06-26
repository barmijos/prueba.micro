print '****************************************'
print ' '
print 'usamos la nueva base:  [bdd_bpichincha1]'
go
USE [bdd_bpichincha1]
GO
print '****************************************'
go
print ' '
print ' '
go
print '****************************************'
print 'Creando los indices en las tablas'
print ' '
print '  [OK]  Tabla Persona'
go
ALTER TABLE dbo.bp_persona
	 ADD CONSTRAINT PK_bp_persona PRIMARY KEY CLUSTERED (id_persona);
go
print '      [OK]  PK_persona'
print '****************************************'
go

print ' '
print ' '
print ' '
print '****************************************'
print ' '
print '  [OK]  Tabla Cuenta'
go
ALTER TABLE dbo.bp_cuenta
	 ADD CONSTRAINT PK_bp_cuenta PRIMARY KEY CLUSTERED (id_cuenta);
	 go
print '      [OK]  PK_bp_cuenta'
go

print '****************************************'
print ' '
print ' '
print ' '
print '****************************************'
print ' '
print '  [OK]  Tabla Cliente'
go
ALTER TABLE dbo.bp_cliente
	 ADD CONSTRAINT PK_bp_cliente PRIMARY KEY CLUSTERED (id_cliente);
	 go
print '      [OK]  PK_bp_cliente'
go
ALTER TABLE dbo.bp_cliente
   ADD CONSTRAINT FK_bp_persona_bp_cliente FOREIGN KEY (id_persona)
      REFERENCES dbo.bp_persona (id_persona)
      ON DELETE CASCADE
      ON UPDATE CASCADE
	 go
print '      [OK]  FK_persona'
go
ALTER TABLE dbo.bp_cliente  
ADD CONSTRAINT UK_id_persona UNIQUE (id_persona);   
GO  
print '      [OK]  UK_id_persona'
print '****************************************'
go

print ' '
print ' '
print ' '
print '****************************************'
print ' '
print '  [OK]  Tabla Cliente Cuenta'
go
ALTER TABLE dbo.bp_cliente_cuenta
	 ADD CONSTRAINT PK_bp_cliente_cuenta PRIMARY KEY CLUSTERED (id_cliente_cuenta);
	 go
print '      [OK]  PK_bp_cliente_cuenta'
go
ALTER TABLE dbo.bp_cliente_cuenta
   ADD CONSTRAINT FK_bp_cliente_cuenta_bp_cliente FOREIGN KEY (id_cliente)
      REFERENCES dbo.bp_cliente (id_cliente)
      ON DELETE CASCADE
      ON UPDATE CASCADE
	 go
print '      [OK]  FK_bp_cliente_cuenta_bp_cliente'
go
ALTER TABLE dbo.bp_cliente_cuenta
   ADD CONSTRAINT FK_bp_cliente_cuenta_bp_cuenta FOREIGN KEY (id_cuenta)
      REFERENCES dbo.bp_cuenta (id_cuenta)
      ON DELETE CASCADE
      ON UPDATE CASCADE
	 go
print '      [OK]  FK_bp_cliente_cuenta_bp_cuenta'
print '****************************************'
go


print ' '
print ' '
print ' '
print '****************************************'
print ' '
print '  [OK]  Tabla Movimiento'
go
ALTER TABLE dbo.bp_movimiento
	 ADD CONSTRAINT PK_bp_movimiento PRIMARY KEY CLUSTERED (id_movimiento);
	 go
print '      [OK]  PK_bp_movimiento'
go
ALTER TABLE dbo.bp_movimiento
   ADD CONSTRAINT FK_bp_movimiento_bp_cuenta FOREIGN KEY (id_cuenta)
      REFERENCES dbo.bp_cuenta (id_cuenta)
      ON DELETE CASCADE
      ON UPDATE CASCADE
	 go
print '      [OK]  FK_persona'
go

print '****************************************'
go
