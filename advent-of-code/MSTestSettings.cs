
// Using Class Level Parallelization because we have far more classes, than methods per class
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]