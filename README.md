# ApartmentSearch

1. Build and run the project.

2. By default ~/apartment/index will be browsed.
	- This page will displays all the records according to Suburb and City with details in tabular form.
	- Each row is highlighted when user hovers over it to give a better view to the user.
	- On the top right of the page LinkButton 'Search Apartments' is visible.

3. On clicking LinkButton 'Search Apartments' user is redirected to url ~/apartment/search.
	- This page has various input fields to search the apartments, click the search button and 
		the results are displayed in the tablular form.
	- the searched text(case-sensitive) is highlited for Address and Suburb
	- To refresh the page click the linkButton'Reset', all the input fields will be set to default
		 and table will be cleared.
	- On the right to 'Reset' linkbutton another linkbutton is visible 'Back'
	- 'Back' linkbutton redirects to the previous page 'Apartments' url:~/apartment/index

4. Each urls browsed by the user are recorded in the log file using log4net.

5. EntityFramework is used to create ORMapper classes named "ApartmentEntity".

6. The provided csv file is stored in the database MS Sql server in the form of 'Apartment' table.

7. Unity container is used to resolve DI


