-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 19-06-2025 a las 23:40:29
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `libreria`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarAutor` (IN `id` INT)   BEGIN
    DELETE FROM Autores WHERE AutorID = id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarInventario` (IN `id` INT)   BEGIN
    DELETE FROM Inventario WHERE InventarioID = id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarLibro` (IN `id` INT)   BEGIN
    DELETE FROM Libros WHERE LibroID = id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertarAutor` (IN `nombreAutor` VARCHAR(100))   BEGIN
    INSERT INTO Autores (Nombre) VALUES (nombreAutor);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertarInventario` (IN `libro_id` INT, IN `cantidad` INT)   BEGIN
    INSERT INTO Inventario (LibroID, Cantidad)
    VALUES (libro_id, cantidad);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertarLibro` (IN `titulo` VARCHAR(150), IN `genero` VARCHAR(50), IN `anio` INT, IN `autor_id` INT)   BEGIN
    INSERT INTO Libros (Titulo, Genero, AñoPublicacion, AutorID)
    VALUES (titulo, genero, anio, autor_id);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `VerAutores` ()   BEGIN
    SELECT * FROM Autores;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `VerInventario` ()   BEGIN
    SELECT I.InventarioID, I.LibroID, I.Cantidad, L.Titulo
    FROM Inventario I
    JOIN Libros L ON I.LibroID = L.LibroID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `VerLibros` ()   BEGIN
    SELECT L.LibroID, L.Titulo, L.Genero, L.AñoPublicacion, L.AutorID, A.Nombre AS Autor
    FROM Libros L
    JOIN Autores A ON L.AutorID = A.AutorID;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `autores`
--

CREATE TABLE `autores` (
  `AutorID` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `autores`
--

INSERT INTO `autores` (`AutorID`, `Nombre`) VALUES
(3, 'Harry specter'),
(4, 'Pancho Villa'),
(5, 'Alejandro Lerner y Kiko Cibrián');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `InventarioID` int(11) NOT NULL,
  `LibroID` int(11) DEFAULT NULL,
  `Cantidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`InventarioID`, `LibroID`, `Cantidad`) VALUES
(2, 3, 5),
(3, 3, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE `libros` (
  `LibroID` int(11) NOT NULL,
  `Titulo` varchar(150) NOT NULL,
  `Genero` varchar(50) DEFAULT NULL,
  `AñoPublicacion` int(11) DEFAULT NULL,
  `AutorID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`LibroID`, `Titulo`, `Genero`, `AñoPublicacion`, `AutorID`) VALUES
(2, 'sxxn', 'jcndjdc', 1999, 3),
(3, 'Don Quijote', 'Ficcion', 1980, 4),
(4, 'Dame', 'Dramatico', 2023, 5);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `autores`
--
ALTER TABLE `autores`
  ADD PRIMARY KEY (`AutorID`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`InventarioID`),
  ADD KEY `LibroID` (`LibroID`);

--
-- Indices de la tabla `libros`
--
ALTER TABLE `libros`
  ADD PRIMARY KEY (`LibroID`),
  ADD KEY `AutorID` (`AutorID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `autores`
--
ALTER TABLE `autores`
  MODIFY `AutorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `inventario`
--
ALTER TABLE `inventario`
  MODIFY `InventarioID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `libros`
--
ALTER TABLE `libros`
  MODIFY `LibroID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD CONSTRAINT `inventario_ibfk_1` FOREIGN KEY (`LibroID`) REFERENCES `libros` (`LibroID`);

--
-- Filtros para la tabla `libros`
--
ALTER TABLE `libros`
  ADD CONSTRAINT `libros_ibfk_1` FOREIGN KEY (`AutorID`) REFERENCES `autores` (`AutorID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
