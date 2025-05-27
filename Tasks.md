English below

# Oppgaver

1. Lag en datamodell bestående av følgende
    - Recipe
    - Har mange Step
    - Har mange Ingredient

2. Legg til Entity Framework Core i prosjektet

3. Lag en Initial migration

4. Deploy en migration til din lokale database

5. Lag en Recipe controller med endepunkt som henter en Recipe med alle underliggende Steps og Ingredients

6. Lag et endepunkt på samme controller som tar inn en liste over Ingredients og returnerer Recipes som bruker disse

7. Se om du klarer å finne selve sql’en som vil bli kjørt i en spørring gjennom debuggeren. (Hint: del opp query og excecution)

8. Lag fullverdig CRUD for Recipe og Ingredient

9. Man skal ikke kunne bruke en Ingredient som ikke finnes i en Recipe

10. Generer script for en migration

11. Rull tilbake en migration, 
    - ... som er deployet til din lokale database 
    - ... som ikke er deployet

# Tasks

1. Add a data model consisting of the following
   - Recipe
   - With many Steps
   - With many Ingredients

2. Add Entity Framework Core to the project

3. Create the initial migration

4. Deploy the migration to your local database

5. Add a Recipe controller with an endpoint that gets a recipe with all the underlying Steps and Ingredients

6. Add an endpoint that accepts a list of Ingredients and returns Recipes that uses them

7. See if you can find the SQL that will be executed on the server with the debugger
   - Hint: Split up the query and the execution

8. Add a full CRUD for Recipe and Ingredient
   - It should not be possible to use an Ingredient that does not exist in a Recipe

9. Generate the script for a migration

10. Roll back a migration
    - ... that has been deployed to your local database
    - ... that has not been deployed
