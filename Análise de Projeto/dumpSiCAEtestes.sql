CREATE DATABASE  IF NOT EXISTS `sicae` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sicae`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: sicae
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aluno`
--

DROP TABLE IF EXISTS `aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aluno` (
  `idAluno` int NOT NULL AUTO_INCREMENT,
  `nomeSocial` varchar(50) DEFAULT NULL,
  `dataNascimento` datetime NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `cep` varchar(8) NOT NULL,
  `email` varbinary(30) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `procedenciaEscolar` varchar(45) NOT NULL,
  `nacionalidade` varchar(20) NOT NULL,
  `identidade` varchar(8) NOT NULL,
  `telefone` varchar(11) NOT NULL,
  `sexo` varchar(1) NOT NULL,
  `certidaoNascimento` varchar(32) NOT NULL,
  `corRaca` varchar(45) NOT NULL,
  `sus` varchar(15) NOT NULL,
  `nis` varchar(11) DEFAULT NULL,
  `bairro` varchar(50) NOT NULL,
  `complemento` varchar(50) DEFAULT NULL,
  `numeroImovel` varchar(5) NOT NULL,
  `nome` varchar(45) NOT NULL,
  PRIMARY KEY (`idAluno`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno`
--

LOCK TABLES `aluno` WRITE;
/*!40000 ALTER TABLE `aluno` DISABLE KEYS */;
INSERT INTO `aluno` VALUES (1,NULL,'1998-04-02 00:00:00','03799259589','Rua Aluizio de Almeida','49509088',_binary 'muelsam98@gmail.com','Itabaiana','Nenhuma','Brasileiro','25088106','7999250295','M','1223411','Pardo','12345678910','12345678910','Centro','Proximo à vila de Zé de Melinea','4233','Samuel Albert'),(3,NULL,'2012-05-12 00:00:00','03499521387','Marinete Barbosa','49505380',_binary 'alivas@gmail.com','Itabaiana','Colegio O Saber','Brasileiro','21344589','79981009823','M','89766569098712678900911232145671','Pardo','987231498923490',NULL,'Miguel Teles de Mendonça',NULL,'336','Alisson Almeida Vasconcelos');
/*!40000 ALTER TABLE `aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunoaula`
--

DROP TABLE IF EXISTS `alunoaula`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunoaula` (
  `idAula` int NOT NULL,
  `estaPresente` tinyint NOT NULL DEFAULT '0',
  `idAluno` int NOT NULL,
  PRIMARY KEY (`idAula`,`idAluno`),
  KEY `fk_Aula_Aluno_Aula_idx` (`idAula`),
  KEY `fk_AlunoAula_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_AlunoAula_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_Aula_Aluno_Aula` FOREIGN KEY (`idAula`) REFERENCES `aula` (`idAula`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunoaula`
--

LOCK TABLES `alunoaula` WRITE;
/*!40000 ALTER TABLE `alunoaula` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunoaula` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunonotificacao`
--

DROP TABLE IF EXISTS `alunonotificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunonotificacao` (
  `idAluno` int NOT NULL,
  `idNotificacao` int NOT NULL,
  PRIMARY KEY (`idAluno`,`idNotificacao`),
  KEY `fk_AlunoNotificacao_Notificacao1_idx` (`idNotificacao`),
  KEY `fk_AlunoNotificacao_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_AlunoNotificacao_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_AlunoNotificacao_Notificacao1` FOREIGN KEY (`idNotificacao`) REFERENCES `notificacao` (`idNotificacao`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunonotificacao`
--

LOCK TABLES `alunonotificacao` WRITE;
/*!40000 ALTER TABLE `alunonotificacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunonotificacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunopessoaresponsavel`
--

DROP TABLE IF EXISTS `alunopessoaresponsavel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunopessoaresponsavel` (
  `idPessoa` int NOT NULL,
  `parentesco` enum('PAI','MAE','AVO','IRMAO','OUTRO') NOT NULL DEFAULT 'PAI',
  `idAluno` int NOT NULL,
  PRIMARY KEY (`idPessoa`,`idAluno`),
  KEY `fk_AlunoPessoa_Pessoa1_idx` (`idPessoa`),
  KEY `fk_AlunoPessoaResponsavel_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_AlunoPessoa_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_AlunoPessoaResponsavel_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunopessoaresponsavel`
--

LOCK TABLES `alunopessoaresponsavel` WRITE;
/*!40000 ALTER TABLE `alunopessoaresponsavel` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunopessoaresponsavel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetRoleClaims_AspNetRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetUserClaims_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `FK_AspNetUserLogins_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('cad7b6c9-97be-4fd1-884d-bbc96718adc9','muelsam98@gmail.com','MUELSAM98@GMAIL.COM','muelsam98@gmail.com','MUELSAM98@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEKgZBFs1SggzphIxNTmm3SyEGudUKZdwywH/tFC43cmcS33LFrB97hj8wIZKQp013g==','UQG6NFOBF53JG4E5BNR7OIROHIMAGDYY','c95964a3-c0d7-46da-b4ec-74fa196eee0e',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aula`
--

DROP TABLE IF EXISTS `aula`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aula` (
  `idAula` int NOT NULL AUTO_INCREMENT,
  `Conteudo` varchar(300) NOT NULL,
  `data` datetime NOT NULL,
  `idProfessorTurmaDisciplina` int NOT NULL,
  PRIMARY KEY (`idAula`),
  KEY `fk_Aula_ProfessorTurmaDisciplina1_idx` (`idProfessorTurmaDisciplina`),
  CONSTRAINT `fk_Aula_ProfessorTurmaDisciplina1` FOREIGN KEY (`idProfessorTurmaDisciplina`) REFERENCES `professorturmadisciplina` (`idProfessorTurmaDisciplina`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aula`
--

LOCK TABLES `aula` WRITE;
/*!40000 ALTER TABLE `aula` DISABLE KEYS */;
INSERT INTO `aula` VALUES (4,'Tempos Verbais','2021-05-22 00:00:00',0),(5,'Português','2021-05-20 00:00:00',0);
/*!40000 ALTER TABLE `aula` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avaliacao` (
  `idAvaliacao` int NOT NULL AUTO_INCREMENT,
  `peso` int NOT NULL,
  `idProfessorTurmaDisciplina` int NOT NULL,
  `nota` decimal(5,2) NOT NULL,
  `idAluno` int NOT NULL,
  PRIMARY KEY (`idAvaliacao`),
  KEY `fk_Avaliacao_ProfessorTurmaDisciplina1_idx` (`idProfessorTurmaDisciplina`),
  KEY `fk_Avaliacao_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_Avaliacao_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_Avaliacao_ProfessorTurmaDisciplina1` FOREIGN KEY (`idProfessorTurmaDisciplina`) REFERENCES `professorturmadisciplina` (`idProfessorTurmaDisciplina`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `avaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `boletim`
--

DROP TABLE IF EXISTS `boletim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boletim` (
  `idBoletim` int NOT NULL AUTO_INCREMENT,
  `ano` int NOT NULL,
  `semestre` int NOT NULL,
  `idAluno` int NOT NULL,
  PRIMARY KEY (`idBoletim`),
  UNIQUE KEY `ano_UNIQUE` (`ano`),
  UNIQUE KEY `semestre_UNIQUE` (`semestre`),
  KEY `fk_Boletim_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_Boletim_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boletim`
--

LOCK TABLES `boletim` WRITE;
/*!40000 ALTER TABLE `boletim` DISABLE KEYS */;
/*!40000 ALTER TABLE `boletim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cidade`
--

DROP TABLE IF EXISTS `cidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cidade` (
  `idCidade` int NOT NULL AUTO_INCREMENT,
  `codIBGE` int NOT NULL,
  `nome` varchar(45) NOT NULL,
  `estado` varchar(45) NOT NULL,
  PRIMARY KEY (`idCidade`),
  UNIQUE KEY `codIBGE_UNIQUE` (`codIBGE`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cidade`
--

LOCK TABLES `cidade` WRITE;
/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;
INSERT INTO `cidade` VALUES (1,2802908,'Itabaiana','Sergipe');
/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diahora`
--

DROP TABLE IF EXISTS `diahora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diahora` (
  `idDiaHora` int NOT NULL AUTO_INCREMENT,
  `horarioInicio` time NOT NULL,
  `horarioTermino` time NOT NULL,
  `diaSemana` enum('SEG','TER','QUA','QUI','SEX','SAB','DOM') NOT NULL,
  PRIMARY KEY (`idDiaHora`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diahora`
--

LOCK TABLES `diahora` WRITE;
/*!40000 ALTER TABLE `diahora` DISABLE KEYS */;
INSERT INTO `diahora` VALUES (1,'09:00:00','10:50:00','TER'),(2,'10:00:00','10:50:00','QUA'),(3,'07:00:00','09:50:00','QUA'),(4,'07:00:00','08:50:00','SEX'),(5,'07:00:00','08:50:00','SEG'),(6,'07:00:00','09:50:00','SEG'),(7,'07:00:00','08:50:00','SEG'),(8,'07:00:00','08:50:00','SEG'),(9,'07:00:00','08:50:00','SEG'),(10,'07:00:00','08:50:00','SEG'),(11,'15:00:00','15:50:00','QUI'),(14,'07:00:00','08:50:00','SEG');
/*!40000 ALTER TABLE `diahora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diahoraprofessorturmadisciplina`
--

DROP TABLE IF EXISTS `diahoraprofessorturmadisciplina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diahoraprofessorturmadisciplina` (
  `idProfessorTurmaDisciplina` int NOT NULL,
  `idDiaHora` int NOT NULL,
  PRIMARY KEY (`idProfessorTurmaDisciplina`,`idDiaHora`),
  KEY `fk_DiaHoraProfessorTurmaDisciplina_ProfessorTurmaDisciplina_idx` (`idProfessorTurmaDisciplina`),
  KEY `fk_DiaHoraProfessorTurmaDisciplina_DiaHora1_idx` (`idDiaHora`),
  CONSTRAINT `fk_DiaHoraProfessorTurmaDisciplina_DiaHora1` FOREIGN KEY (`idDiaHora`) REFERENCES `diahora` (`idDiaHora`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_DiaHoraProfessorTurmaDisciplina_ProfessorTurmaDisciplina1` FOREIGN KEY (`idProfessorTurmaDisciplina`) REFERENCES `professorturmadisciplina` (`idProfessorTurmaDisciplina`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diahoraprofessorturmadisciplina`
--

LOCK TABLES `diahoraprofessorturmadisciplina` WRITE;
/*!40000 ALTER TABLE `diahoraprofessorturmadisciplina` DISABLE KEYS */;
/*!40000 ALTER TABLE `diahoraprofessorturmadisciplina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disciplina`
--

DROP TABLE IF EXISTS `disciplina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disciplina` (
  `idDisciplina` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(30) NOT NULL,
  PRIMARY KEY (`idDisciplina`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplina`
--

LOCK TABLES `disciplina` WRITE;
/*!40000 ALTER TABLE `disciplina` DISABLE KEYS */;
INSERT INTO `disciplina` VALUES (1,'Matematica'),(2,'Geografia');
/*!40000 ALTER TABLE `disciplina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `escola`
--

DROP TABLE IF EXISTS `escola`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `escola` (
  `idEscola` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `telefone` varchar(11) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `cnpj` varchar(14) NOT NULL,
  `email` varchar(30) NOT NULL,
  `codIBGE` int NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `complemento` varchar(50) DEFAULT NULL,
  `cep` varchar(8) NOT NULL,
  `numeroImovel` varchar(5) NOT NULL,
  `idDiretor` int NOT NULL,
  PRIMARY KEY (`idEscola`),
  KEY `fk_Escola_Cidade_idx` (`codIBGE`),
  KEY `fk_Escola_Pessoa1_idx` (`idDiretor`),
  CONSTRAINT `fk_Escola_Cidade1` FOREIGN KEY (`codIBGE`) REFERENCES `cidade` (`codIBGE`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_Escola_Pessoa1` FOREIGN KEY (`idDiretor`) REFERENCES `pessoa` (`idPessoa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `escola`
--

LOCK TABLES `escola` WRITE;
/*!40000 ALTER TABLE `escola` DISABLE KEYS */;
/*!40000 ALTER TABLE `escola` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notificacao`
--

DROP TABLE IF EXISTS `notificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notificacao` (
  `idNotificacao` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(50) NOT NULL,
  `descricao` varchar(150) DEFAULT NULL,
  `prioridade` varchar(45) DEFAULT NULL,
  `remetente` varchar(45) DEFAULT NULL,
  `notificaProfessor` tinyint DEFAULT NULL,
  `notificaResponsavel` tinyint DEFAULT NULL,
  `notificaAluno` tinyint DEFAULT NULL,
  PRIMARY KEY (`idNotificacao`),
  UNIQUE KEY `idNotificacao_UNIQUE` (`idNotificacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notificacao`
--

LOCK TABLES `notificacao` WRITE;
/*!40000 ALTER TABLE `notificacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `notificacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int NOT NULL AUTO_INCREMENT,
  `NomeSocial` varchar(50) NOT NULL,
  `dataNascimento` datetime NOT NULL,
  `CPF` varchar(11) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `CEP` varchar(8) NOT NULL,
  `email` varchar(30) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `profissao` varchar(45) NOT NULL,
  `nacionalidade` varchar(20) NOT NULL,
  `identidade` varchar(8) NOT NULL,
  `telefone` varchar(11) NOT NULL,
  `sexo` varchar(1) NOT NULL,
  `corRaca` varchar(45) NOT NULL,
  `complemento` varchar(50) DEFAULT NULL,
  `numeroImovel` varchar(5) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `tipoPessoa` enum('Diretor','Secretario','Professor','Responsavel') NOT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE KEY `CPF_UNIQUE` (`CPF`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Marcos Oliveira Santos','1980-05-03 00:00:00','67543298745','Francisco Oliveira','49500000','marcosoliseed@seed.gov.br','Itabaiana','Diretor','Brasileiro','21344569','79981009823','M','Branco',NULL,'2341','centro','Diretor');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoanotificacao`
--

DROP TABLE IF EXISTS `pessoanotificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoanotificacao` (
  `idPessoa` int NOT NULL,
  `idNotificacao` int NOT NULL,
  PRIMARY KEY (`idPessoa`,`idNotificacao`),
  KEY `fk_PessoaNotificacao_Notificacao1_idx` (`idNotificacao`),
  KEY `fk_PessoaNotificacao_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_PessoaNotificacao_Notificacao1` FOREIGN KEY (`idNotificacao`) REFERENCES `notificacao` (`idNotificacao`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_PessoaNotificacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoanotificacao`
--

LOCK TABLES `pessoanotificacao` WRITE;
/*!40000 ALTER TABLE `pessoanotificacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoanotificacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turma`
--

DROP TABLE IF EXISTS `turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turma` (
  `idTurma` int NOT NULL AUTO_INCREMENT,
  `nomeTurma` varchar(10) NOT NULL,
  `turno` varchar(10) NOT NULL,
  `anoDaTurma` int NOT NULL,
  `isActive` tinyint NOT NULL,
  `Escola_idEscola` int NOT NULL,
  PRIMARY KEY (`idTurma`),
  KEY `fk_Turma_Escola1_idx` (`Escola_idEscola`),
  CONSTRAINT `fk_Turma_Escola1` FOREIGN KEY (`Escola_idEscola`) REFERENCES `escola` (`idEscola`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turma`
--

LOCK TABLES `turma` WRITE;
/*!40000 ALTER TABLE `turma` DISABLE KEYS */;
/*!40000 ALTER TABLE `turma` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turma_aluno`
--

DROP TABLE IF EXISTS `turma_aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turma_aluno` (
  `idTurma` int NOT NULL,
  `idAluno` int NOT NULL,
  PRIMARY KEY (`idTurma`,`idAluno`),
  KEY `fk_Turma_Aluno_Turma1_idx` (`idTurma`),
  KEY `fk_Turma_Aluno_Aluno1_idx` (`idAluno`),
  CONSTRAINT `fk_Turma_Aluno_Aluno1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_Turma_Aluno_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`idTurma`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turma_aluno`
--

LOCK TABLES `turma_aluno` WRITE;
/*!40000 ALTER TABLE `turma_aluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `turma_aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'sicae'
--

--
-- Dumping routines for database 'sicae'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-06 15:46:15
