
var cmd = new RootCommand();
return cmd.Parse(args).Invoke();

// TODO: CI/CD mode vs 'nice' mode
// TODO: Consider using Spectre.Console