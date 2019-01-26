/* Usuarios */
INSERT INTO usuario(nick, password, nombre, apellido, creado, activo) VALUES('admin', '123', 'Admin', 'Istrator', GETDATE(), 1);

/* Roles */
INSERT INTO rol(codigo, descripcion) VALUES('ADMIN', 'Administrador');
INSERT INTO rol(codigo, descripcion) VALUES('CLIEN', 'Cliente');

/* Permisos */
/*INSERT INTO permiso(codigo, descripcion) VALUES('VIEW_CAJA', 'Ver menu de caja');*/

/* Permisos a roles */
INSERT INTO rol_permiso(permiso_id, rol_id)
SELECT s.id, r.id FROM permiso s JOIN rol r ON r.codigo = 'ADMIN'
WHERE s.id NOT IN (SELECT permiso_id FROM rol_permiso WHERE rol_id = (SELECT id FROM rol WHERE codigo = 'ADMIN'));

/*INSERT INTO rol_permiso(permiso_id, rol_id) VALUES((SELECT id FROM permiso WHERE codigo = 'VIEW_CAJA'), (SELECT id FROM rol WHERE codigo = 'ENTRE'));*/

/* Roles a usuarios */
INSERT INTO usuario_rol(usuario_id, rol_id) VALUES((SELECT id FROM usuario WHERE nick = 'admin'), (SELECT id FROM rol WHERE codigo = 'ADMIN'));
