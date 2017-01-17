-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-11-2014 a las 12:06:24
-- Versión del servidor: 5.5.32
-- Versión de PHP: 5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `ajax`
--
-- CREATE DATABASE IF NOT EXISTS `ajax` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
-- USE `ajax`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `centros`
--

CREATE TABLE IF NOT EXISTS `centros` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombrecentro` varchar(150) NOT NULL,
  `localidad` varchar(100) NOT NULL,
  `provincia` varchar(50) NOT NULL,
  `telefono` varchar(9) NOT NULL,
  `fechavisita` date NOT NULL,
  `numvisitantes` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Volcado de datos para la tabla `centros`
--

INSERT INTO `centros` (`id`, `nombrecentro`, `localidad`, `provincia`, `telefono`, `fechavisita`, `numvisitantes`) VALUES
(1, 'IES Ramon Mª Aller Ulloa', 'Lalin', 'Pontevedra', '986780114', '2010-11-26', 90),
(2, 'IES A Piringalla', 'Lugo', 'Lugo', '982212010', '2010-11-26', 85),
(3, 'IES San Clemente', 'Santiago de Compostela', 'A Coruña', '981580496', '2010-11-26', 60),
(4, 'IES de Teis', 'Vigo', 'Pontevedra', '986373811', '2010-11-27', 72),
(5, 'IES Leliadoura', 'Ribeira', 'A Coruña', '981874633', '2010-11-25', 0),
(6, 'IES Cruceiro Baleares', 'Culleredo', 'A Coruña', '981660700', '2010-11-26', 30),
(7, 'IES Leliadoura', 'Ribeira', 'A Coruña', '981874633', '2010-11-25', 50),
(8, 'IES Cruceiro Baleares', 'Culleredo', 'A Coruña', '981660700', '2010-11-26', 30),
(9, 'IES As Lagoas', 'Ourense', 'Ourense', '988391325', '2010-11-26', 35),
(10, 'IES As Fontiñas', 'Santiago de Compostela', 'A Coruña', '981573440', '2010-11-27', 64);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rss`
--

CREATE TABLE IF NOT EXISTS `rss` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(200) NOT NULL,
  `url` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Volcado de datos para la tabla `rss`
--

INSERT INTO `rss` (`id`, `titulo`, `url`) VALUES
(3, 'el pais españa', 'http://ep00.epimg.net/rss/elpais/portada.xml'),
(5, 'el pais deportes', 'http://elpais.com/tag/rss/futbol/a/');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
