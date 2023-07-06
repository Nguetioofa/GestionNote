-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3309
-- Généré le : Dim 19 fév. 2023 à 11:55
-- Version du serveur :  5.7.40-log
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestionnote`
--

-- --------------------------------------------------------

--
-- Structure de la table `etablissement`
--

DROP TABLE IF EXISTS `etablissement`;
CREATE TABLE IF NOT EXISTS `etablissement` (
  `idetablissement` int(11) NOT NULL AUTO_INCREMENT,
  `NomEtablissement` varchar(45) NOT NULL,
  `VilleEtablissement` varchar(45) DEFAULT NULL,
  `Telephone` int(9) DEFAULT NULL,
  PRIMARY KEY (`idetablissement`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etablissement`
--

INSERT INTO `etablissement` (`idetablissement`, `NomEtablissement`, `VilleEtablissement`, `Telephone`) VALUES
(1, 'IUC', 'Douala', 65545454),
(2, 'Universite de Douala', 'Douala', 224556578),
(3, 'IUG', 'Douala', 658522);

-- --------------------------------------------------------

--
-- Structure de la table `etudiants`
--

DROP TABLE IF EXISTS `etudiants`;
CREATE TABLE IF NOT EXISTS `etudiants` (
  `id_etudiants` int(11) NOT NULL AUTO_INCREMENT,
  `nom_etudiants` varchar(45) NOT NULL,
  `prenom_etudiants` varchar(45) DEFAULT NULL,
  `telephone_etudiants` varchar(9) DEFAULT NULL,
  `filiere_etudiants` varchar(45) DEFAULT NULL,
  `niveau_etudiants` int(11) DEFAULT NULL,
  `annee_academique` varchar(9) NOT NULL,
  `date_naiss_etudiants` date NOT NULL,
  `matricule_etudiants` varchar(15) DEFAULT NULL,
  `idetablissement` int(11) NOT NULL,
  PRIMARY KEY (`id_etudiants`),
  KEY `fk_etudiants_etablissement1` (`idetablissement`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etudiants`
--

INSERT INTO `etudiants` (`id_etudiants`, `nom_etudiants`, `prenom_etudiants`, `telephone_etudiants`, `filiere_etudiants`, `niveau_etudiants`, `annee_academique`, `date_naiss_etudiants`, `matricule_etudiants`, `idetablissement`) VALUES
(1, 'YTest', 'Test', '442121', 'Genie logiciel', 2, '2022-2023', '2023-02-08', '22S2478', 1),
(2, 'Tchaa', 'Alex', '698542389', 'Genie logiciel', 3, '2022-2023', '1998-02-18', '23TG5444', 1),
(3, 'Ngueukeu', 'Lionnel', '690101320', 'Genie logiciel', 3, '2022-2023', '2016-02-19', '22JK548', 2),
(4, 'Penpen', 'Berboss', '698452357', 'Genie civil', 5, '2022-2023', '2017-02-19', '20PDU5856', 3),
(5, 'Melatagia', 'Novic', '685235796', 'Soin Sante', 2, '2022-2023', '1960-02-19', '17JJD452', 2),
(6, 'Nintcheu', 'Roberto', '225986523', 'TIC', 1, '2022-2023', '2000-11-30', '14JDH33', 2);

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

DROP TABLE IF EXISTS `matiere`;
CREATE TABLE IF NOT EXISTS `matiere` (
  `code_matiere` int(11) NOT NULL AUTO_INCREMENT,
  `nom_matiere` varchar(45) NOT NULL,
  `nbr_credit_matiere` int(2) NOT NULL,
  PRIMARY KEY (`code_matiere`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `matiere`
--

INSERT INTO `matiere` (`code_matiere`, `nom_matiere`, `nbr_credit_matiere`) VALUES
(1, 'Programmatio C#', 5),
(2, 'Modelisation Objet UML', 3);

-- --------------------------------------------------------

--
-- Structure de la table `note`
--

DROP TABLE IF EXISTS `note`;
CREATE TABLE IF NOT EXISTS `note` (
  `id_note` int(11) NOT NULL AUTO_INCREMENT,
  `cc_note` double DEFAULT NULL,
  `tp_note` double DEFAULT NULL,
  `exam_note` double DEFAULT NULL,
  `ratrapage_note` double DEFAULT NULL,
  `id_etudiants` int(11) NOT NULL,
  `code_matiere` int(11) NOT NULL,
  PRIMARY KEY (`id_note`),
  KEY `fk_note_etudiants1` (`id_etudiants`),
  KEY `fk_note_matiere1` (`code_matiere`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `note`
--

INSERT INTO `note` (`id_note`, `cc_note`, `tp_note`, `exam_note`, `ratrapage_note`, `id_etudiants`, `code_matiere`) VALUES
(2, 17, 14, 15, NULL, 2, 1),
(3, 11, NULL, 19, NULL, 1, 1),
(7, 16, NULL, NULL, NULL, 2, 2),
(8, 17, 18, 15, NULL, 3, 2),
(9, 17, 19, 14, NULL, 4, 2),
(10, NULL, 20, 13, NULL, 5, 2),
(11, 9, 16, 2, 18, 6, 1);

-- --------------------------------------------------------

--
-- Structure de la table `parametre`
--

DROP TABLE IF EXISTS `parametre`;
CREATE TABLE IF NOT EXISTS `parametre` (
  `idParametre` int(11) NOT NULL AUTO_INCREMENT,
  `NomParametre` varchar(45) NOT NULL,
  `ValeurParametre` varchar(45) NOT NULL,
  PRIMARY KEY (`idParametre`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `parametre`
--

INSERT INTO `parametre` (`idParametre`, `NomParametre`, `ValeurParametre`) VALUES
(1, 'NomAdmin', 'Admin'),
(2, 'MotPasse', '123456789');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `etudiants`
--
ALTER TABLE `etudiants`
  ADD CONSTRAINT `fk_etudiants_etablissement1` FOREIGN KEY (`idetablissement`) REFERENCES `etablissement` (`idetablissement`);

--
-- Contraintes pour la table `note`
--
ALTER TABLE `note`
  ADD CONSTRAINT `fk_note_etudiants1` FOREIGN KEY (`id_etudiants`) REFERENCES `etudiants` (`id_etudiants`),
  ADD CONSTRAINT `fk_note_matiere1` FOREIGN KEY (`code_matiere`) REFERENCES `matiere` (`code_matiere`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
