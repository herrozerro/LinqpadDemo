<Query Kind="Expression">
  <Connection>
    <ID>8fc2abf7-9f71-4805-920b-629e3b7f5264</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <NoPluralization>true</NoPluralization>
    <NoCapitalization>true</NoCapitalization>
    <Database>NorthWind</Database>
  </Connection>
  <Namespace>LINQPad.FSharpExtensions</Namespace>
</Query>

//simple table call
Categories

//Table Call with where
Categories.Where(c => c.CategoryID > 2)

//Projection
Categories.Where(c => c.CategoryID == 2)
.Select(c => new { c, c.Products, c.Products.First().OrderDetails })