
# EF Core Performance Benchmarks

## Overview
This repository contains benchmarks comparing two different querying methods using Entity Framework Core: **LINQ to Entities** and **Precompiled Queries**. The benchmarks demonstrate the performance differences in execution time, memory allocation, and system resource utilization between the two methods.

## Benchmark Results
The following table summarizes the benchmark results showcasing the differences in performance metrics between the regular LINQ to Entities approach and the precompiled query method.

| Method         | Mean (us) | Error (us) | StdDev (us) | Gen0     | Gen1    | Allocated (KB) |
|----------------|-----------|------------|-------------|----------|---------|----------------|
| LinqToEntities | 198.66    | 1.364      | 1.139       | 52.7344  | 8.7891  | 432.09         |
| CompiledQuery  | 62.78     | 0.748      | 0.663       | 11.8408  | 1.8311  | 97.45          |

### Analysis
The precompiled query method significantly outperforms the regular LINQ to Entities approach. The main advantages are:
- **Execution Time**: The precompiled query is much faster, with a mean execution time of just 62.78 microseconds, compared to 198.66 microseconds for the regular query.
- **Consistency and Stability**: The lower error and standard deviation values for the precompiled query suggest more consistent and stable performance.
- **Resource Efficiency**: The precompiled query uses fewer system resources, as evidenced by fewer garbage collection operations in both Gen0 and Gen1, and it allocates less memory per operation.

## Conclusion
Using precompiled queries in Entity Framework Core can greatly enhance performance, especially in scenarios where the same query is executed multiple times. The reduced execution time and lower system resource usage make it an ideal choice for high-performance applications. This repository provides a clear demonstration of the benefits and encourages developers to consider precompiled queries for optimizing database interactions in their applications.

## How to Run Benchmarks
To run these benchmarks yourself, clone this repository and execute the following command in the root directory:
```
dotnet run -c Release
```
This will run the benchmarks in a release configuration, giving you the performance metrics directly on your machine.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
