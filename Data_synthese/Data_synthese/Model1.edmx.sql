



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 01/26/2014 07:43:55
-- Generated from EDMX file: C:\DropBox\Cours iPhone\Session 6 Projet synthèse\projet_synthese\projet_synthese\projet_synthese\Data_synthese\Data_synthese\Model1.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `CriOiseau` DROP CONSTRAINT `FK_OiseauCriOiseau`;
--    ALTER TABLE `Observation` DROP CONSTRAINT `FK_OiseauObservation`;
--    ALTER TABLE `Photo` DROP CONSTRAINT `FK_OiseauPhoto`;
--    ALTER TABLE `Alerte` DROP CONSTRAINT `FK_Alerteobservation`;
--    ALTER TABLE `Usager` DROP CONSTRAINT `FK_observationusager`;
--    ALTER TABLE `PhotoObservationSet` DROP CONSTRAINT `FK_PhotoObservationObservation`;
--    ALTER TABLE `SonObservationSet` DROP CONSTRAINT `FK_SonObservationObservation`;
--    ALTER TABLE `Message` DROP CONSTRAINT `FK_MessageUsagerUsager`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `CriOiseau`;
    DROP TABLE IF EXISTS `Observation`;
    DROP TABLE IF EXISTS `Oiseau`;
    DROP TABLE IF EXISTS `Photo`;
    DROP TABLE IF EXISTS `Usager`;
    DROP TABLE IF EXISTS `Message`;
    DROP TABLE IF EXISTS `Alerte`;
    DROP TABLE IF EXISTS `PhotoObservationSet`;
    DROP TABLE IF EXISTS `SonObservationSet`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

CREATE TABLE `CriOiseau`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Son` longblob NOT NULL, 
	`Description` varchar (1000) NOT NULL, 
	`IDOiseau` int NOT NULL);

ALTER TABLE `CriOiseau` ADD PRIMARY KEY (Id);




CREATE TABLE `Observation`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`DateObservation` datetime NOT NULL, 
	`Position` int NOT NULL, 
	`IDUsager` int NOT NULL, 
	`IDOiseau` int NOT NULL, 
	`IDAlerte` int);

ALTER TABLE `Observation` ADD PRIMARY KEY (Id);




CREATE TABLE `Oiseau`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Espece` varchar (1000) NOT NULL, 
	`Description` varchar (1000) NOT NULL, 
	`IDPhoto` int NOT NULL);

ALTER TABLE `Oiseau` ADD PRIMARY KEY (Id);




CREATE TABLE `Photo`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Image` longblob NOT NULL, 
	`Description` varchar (1000) NOT NULL, 
	`IDOiseau` int NOT NULL, 
	`ImageMiniature` longblob NOT NULL);

ALTER TABLE `Photo` ADD PRIMARY KEY (Id);




CREATE TABLE `Usager`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`NomUsager` varchar (20) NOT NULL, 
	`MotPasse` varchar (20) NOT NULL, 
	`Administrateur` bool NOT NULL, 
	`IDObservation` int NOT NULL);

ALTER TABLE `Usager` ADD PRIMARY KEY (Id);




CREATE TABLE `Message`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Texte` varchar (1000) NOT NULL, 
	`DateHeure` datetime NOT NULL, 
	`IDUsager` int NOT NULL, 
	`IDObservation` int, 
	`Usager_Id` int);

ALTER TABLE `Message` ADD PRIMARY KEY (Id);




CREATE TABLE `Alerte`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`IDObservation` int NOT NULL, 
	`observation_Id` int NOT NULL);

ALTER TABLE `Alerte` ADD PRIMARY KEY (Id);




CREATE TABLE `PhotoObservationSet`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Image` longblob NOT NULL, 
	`Description` varchar (1000) NOT NULL, 
	`IDObservation` int NOT NULL, 
	`ImageMiniature` longblob NOT NULL, 
	`Commentaire` varchar (1000) NOT NULL, 
	`Observation_Id` int);

ALTER TABLE `PhotoObservationSet` ADD PRIMARY KEY (Id);




CREATE TABLE `SonObservationSet`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Son` longblob NOT NULL, 
	`Description` varchar (1000) NOT NULL, 
	`IDObservation` int NOT NULL, 
	`Observation_Id` int NOT NULL);

ALTER TABLE `SonObservationSet` ADD PRIMARY KEY (Id);






-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `IDOiseau` in table 'CriOiseau'

ALTER TABLE `CriOiseau`
ADD CONSTRAINT `FK_OiseauCriOiseau`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `Oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauCriOiseau'

CREATE INDEX `IX_FK_OiseauCriOiseau` 
    ON `CriOiseau`
    (`IDOiseau`);

-- Creating foreign key on `IDOiseau` in table 'Observation'

ALTER TABLE `Observation`
ADD CONSTRAINT `FK_OiseauObservation`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `Oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauObservation'

CREATE INDEX `IX_FK_OiseauObservation` 
    ON `Observation`
    (`IDOiseau`);

-- Creating foreign key on `IDOiseau` in table 'Photo'

ALTER TABLE `Photo`
ADD CONSTRAINT `FK_OiseauPhoto`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `Oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauPhoto'

CREATE INDEX `IX_FK_OiseauPhoto` 
    ON `Photo`
    (`IDOiseau`);

-- Creating foreign key on `observation_Id` in table 'Alerte'

ALTER TABLE `Alerte`
ADD CONSTRAINT `FK_Alerteobservation`
    FOREIGN KEY (`observation_Id`)
    REFERENCES `Observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Alerteobservation'

CREATE INDEX `IX_FK_Alerteobservation` 
    ON `Alerte`
    (`observation_Id`);

-- Creating foreign key on `IDObservation` in table 'Usager'

ALTER TABLE `Usager`
ADD CONSTRAINT `FK_observationusager`
    FOREIGN KEY (`IDObservation`)
    REFERENCES `Observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_observationusager'

CREATE INDEX `IX_FK_observationusager` 
    ON `Usager`
    (`IDObservation`);

-- Creating foreign key on `Observation_Id` in table 'PhotoObservationSet'

ALTER TABLE `PhotoObservationSet`
ADD CONSTRAINT `FK_PhotoObservationObservation`
    FOREIGN KEY (`Observation_Id`)
    REFERENCES `Observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoObservationObservation'

CREATE INDEX `IX_FK_PhotoObservationObservation` 
    ON `PhotoObservationSet`
    (`Observation_Id`);

-- Creating foreign key on `Observation_Id` in table 'SonObservationSet'

ALTER TABLE `SonObservationSet`
ADD CONSTRAINT `FK_SonObservationObservation`
    FOREIGN KEY (`Observation_Id`)
    REFERENCES `Observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SonObservationObservation'

CREATE INDEX `IX_FK_SonObservationObservation` 
    ON `SonObservationSet`
    (`Observation_Id`);

-- Creating foreign key on `Usager_Id` in table 'Message'

ALTER TABLE `Message`
ADD CONSTRAINT `FK_MessageUsagerUsager`
    FOREIGN KEY (`Usager_Id`)
    REFERENCES `Usager`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageUsagerUsager'

CREATE INDEX `IX_FK_MessageUsagerUsager` 
    ON `Message`
    (`Usager_Id`);

-- Creating foreign key on `IDObservation` in table 'Message'

ALTER TABLE `Message`
ADD CONSTRAINT `FK_ObservationMessage`
    FOREIGN KEY (`IDObservation`)
    REFERENCES `Observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObservationMessage'

CREATE INDEX `IX_FK_ObservationMessage` 
    ON `Message`
    (`IDObservation`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
