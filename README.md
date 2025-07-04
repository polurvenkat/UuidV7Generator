## UuidV7Generator

A fast, dependency-free .NET library to generate UUID v7 identifiers (time-ordered UUIDs) in your applications.

UUID v7 combines:
	•	UNIX epoch milliseconds for time-based ordering (ideal for databases like PostgreSQL).
	•	Random entropy to avoid collisions.

Features
	•	Generates UUID v7 compliant IDs.
	•	Compatible with .NET Standard 2.0+ and .NET 6/7/8/9.
	•	Suitable for sequential keys in PostgreSQL and other databases.
	•	No external dependencies.

## Installation

Install from NuGet:

dotnet add package UuidV7Generator

or using the Package Manager:

Install-Package UuidV7Generator

## Usage

using UuidV7Generator;

Guid id = UuidV7.NewUuid();
Console.WriteLine(id);

Sample output:

51d69701-0119-ed70-8270-098845587bd2

Target Frameworks
	•	.NET Standard 2.0+
	•	.NET 6, 7, 8, 9

## License

MIT License

## Contributing

Feel free to open issues or pull requests.