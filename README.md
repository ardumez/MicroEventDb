# MicroEventDb

### INDEX Format

| Index | 1     |
|-------|-------|
| Data  | 1, 10 |

Each Data value point on the first page of row of table

### TABLE Format

| Index | 1       | Index | 2       | Index | 3    |
|-------|---------|-------|---------|-------|------|
| Data  | 1, 3, 5 | Data  | 2, 4, 6 | Data  | Data |

The first page have all pointer for each page of the row

## Documentation

https://www.geeksforgeeks.org/b-tree-set-1-introduction-2/

https://www.dotnetcurry.com/patterns-practices/1407/producer-consumer-pattern-dotnet-csharp

http://www.nimaara.com/2017/07/01/practical-parallelization-with-map-reduce-in-c/



KeepSychronise two microservice with different storage, with decorate message that transite.
