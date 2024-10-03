SELECT * 
FROM Productos p
JOIN Generos g ON p.Pro_GeneroId = g.GeneroId
WHERE g.Gen_Nombre = 'Hombre' AND p.Pro_Activo = 1;

SELECT * FROM Generos

SELECT * FROM Tallas
SELECT * FROM Productos
SELECT * FROM ProductoImagenes
SELECT * FROM PromocionProductos
SELECT * FROM ProductoDescuentos
SELECT * FROM ProductoTallas


SELECT * FROM AspNetUsers


EXEC ProductoColor_Delete @ProductoId = 11, @ColorId = 8
SELECT * FROM ProductoColor


SELECT c.ColorId, c.Col_Nombre, c.Col_Hexadecimal
FROM ProductoColor pc
INNER JOIN Colores c ON pc.ColorId = c.ColorId -- Asegúrate de usar 'Colores' en el SP
WHERE pc.ProductoId = 6;


ALTER TABLE Logs
ALTER COLUMN UsuarioId INT NULL;


ALTER TABLE Logs
ADD CONSTRAINT FK_Logs_Usuarios
FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId) ON DELETE SET NULL;
