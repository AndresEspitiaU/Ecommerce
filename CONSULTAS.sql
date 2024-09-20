SELECT * 
FROM Productos p
JOIN Generos g ON p.Pro_GeneroId = g.GeneroId
WHERE g.Gen_Nombre = 'Hombre' AND p.Pro_Activo = 1;


SELECT * FROM Productos
SELECT * FROM ProductoImagenes
SELECT * FROM Generos