



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 03/29/2014 10:41:03
-- Generated from EDMX file: C:\Sources\synthese\projet_synthese\Data_synthese\Data_synthese\Model_Synthese.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `alerte` DROP CONSTRAINT `FK_Alertes_Oiseaux`;
--    ALTER TABLE `crioiseau` DROP CONSTRAINT `FK_CriOiseaux_Oiseaux`;
--    ALTER TABLE `message` DROP CONSTRAINT `FK_Usagers_Messages`;
--    ALTER TABLE `observation` DROP CONSTRAINT `FK_Observations_Oiseaux`;
--    ALTER TABLE `photoobservation` DROP CONSTRAINT `FK_Observations_PhotoObservations`;
--    ALTER TABLE `sonobservation` DROP CONSTRAINT `FK_Observations_SonObservations`;
--    ALTER TABLE `observation` DROP CONSTRAINT `FK_Observations_Usagers`;
--    ALTER TABLE `photo` DROP CONSTRAINT `FK_Photos_Oiseaux`;
--    ALTER TABLE `message` DROP CONSTRAINT `FK_observationmessage`;
--    ALTER TABLE `alerte` DROP CONSTRAINT `FK_usageralerte`;
--    ALTER TABLE `Commentaire` DROP CONSTRAINT `FK_observationCommentaire`;
--    ALTER TABLE `Commentaire` DROP CONSTRAINT `FK_usagerCommentaire`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `alerte`;
    DROP TABLE IF EXISTS `crioiseau`;
    DROP TABLE IF EXISTS `message`;
    DROP TABLE IF EXISTS `observation`;
    DROP TABLE IF EXISTS `oiseau`;
    DROP TABLE IF EXISTS `photoobservation`;
    DROP TABLE IF EXISTS `photo`;
    DROP TABLE IF EXISTS `sonobservation`;
    DROP TABLE IF EXISTS `usager`;
    DROP TABLE IF EXISTS `Commentaire`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

CREATE TABLE `alerte`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`IDUsager` int NOT NULL, 
	`IDOiseau` int NOT NULL);

ALTER TABLE `alerte` ADD PRIMARY KEY (Id);




CREATE TABLE `crioiseau`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Son` longblob, 
	`Description` longtext, 
	`IDOiseau` int NOT NULL, 
	`Path` varchar (255) NOT NULL);

ALTER TABLE `crioiseau` ADD PRIMARY KEY (Id);




CREATE TABLE `message`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Texte` varchar (250) NOT NULL, 
	`DateHeure` datetime NOT NULL, 
	`IDUsager` int NOT NULL, 
	`IDObservation` int);

ALTER TABLE `message` ADD PRIMARY KEY (Id);




CREATE TABLE `observation`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`DateObservation` datetime NOT NULL, 
	`PositionLong` double, 
	`IDUsager` int NOT NULL, 
	`IDOiseau` int NOT NULL, 
	`PositionLat` double, 
	`Titre` varchar (100) NOT NULL, 
	`Detail` longtext NOT NULL);

ALTER TABLE `observation` ADD PRIMARY KEY (Id);




CREATE TABLE `oiseau`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Espece` longtext, 
	`Description` longtext);

ALTER TABLE `oiseau` ADD PRIMARY KEY (Id);




CREATE TABLE `photoobservation`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Image` longblob, 
	`Description` longtext, 
	`IDObservation` int NOT NULL, 
	`ImageMiniature` longblob, 
	`Commentaire` varchar (200), 
	`Path` varchar (255) NOT NULL);

ALTER TABLE `photoobservation` ADD PRIMARY KEY (Id);




CREATE TABLE `photo`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Image` longblob NOT NULL, 
	`Description` longtext, 
	`IDOiseau` int NOT NULL, 
	`ImageMiniature` longblob, 
	`Path` varchar (255) NOT NULL);

ALTER TABLE `photo` ADD PRIMARY KEY (Id);




CREATE TABLE `sonobservation`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Son` longblob, 
	`Description` longtext, 
	`IDObservation` int NOT NULL, 
	`Path` varchar (255) NOT NULL);

ALTER TABLE `sonobservation` ADD PRIMARY KEY (Id);




CREATE TABLE `usager`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`NomUsager` varchar (20) NOT NULL, 
	`MotPasse` varchar (128) NOT NULL, 
	`Administrateur` bool NOT NULL, 
	`Courriel` varchar (50) NOT NULL, 
	`Nom` char (50) NOT NULL);

ALTER TABLE `usager` ADD PRIMARY KEY (Id);




CREATE TABLE `Commentaire`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Texte` longtext NOT NULL, 
	`observationId` int NOT NULL, 
	`IDUsager` int NOT NULL);

ALTER TABLE `Commentaire` ADD PRIMARY KEY (Id);






-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `IDOiseau` in table 'alerte'

ALTER TABLE `alerte`
ADD CONSTRAINT `FK_Alertes_Oiseaux`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Alertes_Oiseaux'

CREATE INDEX `IX_FK_Alertes_Oiseaux` 
    ON `alerte`
    (`IDOiseau`);

-- Creating foreign key on `IDOiseau` in table 'crioiseau'

ALTER TABLE `crioiseau`
ADD CONSTRAINT `FK_CriOiseaux_Oiseaux`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CriOiseaux_Oiseaux'

CREATE INDEX `IX_FK_CriOiseaux_Oiseaux` 
    ON `crioiseau`
    (`IDOiseau`);

-- Creating foreign key on `IDUsager` in table 'message'

ALTER TABLE `message`
ADD CONSTRAINT `FK_Usagers_Messages`
    FOREIGN KEY (`IDUsager`)
    REFERENCES `usager`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usagers_Messages'

CREATE INDEX `IX_FK_Usagers_Messages` 
    ON `message`
    (`IDUsager`);

-- Creating foreign key on `IDOiseau` in table 'observation'

ALTER TABLE `observation`
ADD CONSTRAINT `FK_Observations_Oiseaux`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Observations_Oiseaux'

CREATE INDEX `IX_FK_Observations_Oiseaux` 
    ON `observation`
    (`IDOiseau`);

-- Creating foreign key on `IDObservation` in table 'photoobservation'

ALTER TABLE `photoobservation`
ADD CONSTRAINT `FK_Observations_PhotoObservations`
    FOREIGN KEY (`IDObservation`)
    REFERENCES `observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Observations_PhotoObservations'

CREATE INDEX `IX_FK_Observations_PhotoObservations` 
    ON `photoobservation`
    (`IDObservation`);

-- Creating foreign key on `IDObservation` in table 'sonobservation'

ALTER TABLE `sonobservation`
ADD CONSTRAINT `FK_Observations_SonObservations`
    FOREIGN KEY (`IDObservation`)
    REFERENCES `observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Observations_SonObservations'

CREATE INDEX `IX_FK_Observations_SonObservations` 
    ON `sonobservation`
    (`IDObservation`);

-- Creating foreign key on `IDUsager` in table 'observation'

ALTER TABLE `observation`
ADD CONSTRAINT `FK_Observations_Usagers`
    FOREIGN KEY (`IDUsager`)
    REFERENCES `usager`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Observations_Usagers'

CREATE INDEX `IX_FK_Observations_Usagers` 
    ON `observation`
    (`IDUsager`);

-- Creating foreign key on `IDOiseau` in table 'photo'

ALTER TABLE `photo`
ADD CONSTRAINT `FK_Photos_Oiseaux`
    FOREIGN KEY (`IDOiseau`)
    REFERENCES `oiseau`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Photos_Oiseaux'

CREATE INDEX `IX_FK_Photos_Oiseaux` 
    ON `photo`
    (`IDOiseau`);

-- Creating foreign key on `IDObservation` in table 'message'

ALTER TABLE `message`
ADD CONSTRAINT `FK_observationmessage`
    FOREIGN KEY (`IDObservation`)
    REFERENCES `observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_observationmessage'

CREATE INDEX `IX_FK_observationmessage` 
    ON `message`
    (`IDObservation`);

-- Creating foreign key on `IDUsager` in table 'alerte'

ALTER TABLE `alerte`
ADD CONSTRAINT `FK_usageralerte`
    FOREIGN KEY (`IDUsager`)
    REFERENCES `usager`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usageralerte'

CREATE INDEX `IX_FK_usageralerte` 
    ON `alerte`
    (`IDUsager`);

-- Creating foreign key on `observationId` in table 'Commentaire'

ALTER TABLE `Commentaire`
ADD CONSTRAINT `FK_observationCommentaire`
    FOREIGN KEY (`observationId`)
    REFERENCES `observation`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_observationCommentaire'

CREATE INDEX `IX_FK_observationCommentaire` 
    ON `Commentaire`
    (`observationId`);

-- Creating foreign key on `IDUsager` in table 'Commentaire'

ALTER TABLE `Commentaire`
ADD CONSTRAINT `FK_usagerCommentaire`
    FOREIGN KEY (`IDUsager`)
    REFERENCES `usager`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usagerCommentaire'

CREATE INDEX `IX_FK_usagerCommentaire` 
    ON `Commentaire`
    (`IDUsager`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
