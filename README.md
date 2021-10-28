"# graphql-net-demo" 

## Run project in docker

`cd docker-compose && docker-compose up --build`

## Query examples

```graphql

# Projections

query getEmployeesWithProjectionsFields {
  employeesWithProjection {
    id firstName
  }
}

query getEmployeesWithProjectionsJoins {
  employeesWithProjection {
    id firstName lastName projectEmployees { project { name }}
  }
}

# Filtering

query getEmployeesWithFilteringById {
  employeesWithFiltering(
    where:{
      id: {eq:"60ad0483-fe3b-46b8-847a-ec898ad9f7ca"}
  }){
    id firstName lastName
  }
}

query getEmployeesWithFilteringByName {
  employeesWithFiltering(
    where:{
      firstName: {contains: "Joe"}
  }){
    firstName lastName
  }
}

# Ordering

query getEmployeesWithSorting{
  employeesWithSorting(order:{firstName:DESC}){
    firstName
  }
}

# Paging

query getEmployeesWithPaging{
  employeesWithPaging(first: 5){
    pageInfo { hasNextPage}
    nodes { id firstName} 
    totalCount
  }
}

# ALL

query getEmployees{
  employees(
    first:10,
    where: {projectEmployees: {all: {startDate: {gt: "01/01/2021"}}}},
    order: {lastName: ASC}
  ) {
    nodes { id firstName } 
    totalCount 
  }
}

```

## Mutation examples

```graphql

mutation addProject{
  addProject(command:{name:"HotChocolate"}){
    id name
  }
}

mutation addEmployee{
  addEmployee(command:{
    firstName: "Jesse"
    lastName: "Pinkman"
    email: "test@gmail.com"
  }) {
    id firstName lastName
  }
}

```