import 'dart:convert';
import 'dart:io';
import 'package:args/args.dart';

const lineNumber = 'line-number';

void main(List<String> arguments) {
  exitCode = 0; //presume success
  final parser = ArgParser()
    ..addFlag(lineNumber,
        abbr: 'n', negatable: false, help: 'Show line numbers');

  final results = parser.parse(arguments);
  final paths = results.rest;

  dcat(paths, showLineNumbers: results[lineNumber] as bool);
}

Future<void> dcat(List<String> paths, {bool showLineNumbers = false}) async {
  if (paths.isEmpty) {
    await stdin.pipe(stdout);
  } else {
    for (final path in paths) {
      var lineNumber = 1;
      final lines = utf8.decoder
          .bind(File(path).openRead())
          .transform(const LineSplitter());

      try {
        await for (final line in lines) {
          if (showLineNumbers) {
            stdout.write('${lineNumber++} ');
          }
          stdout.writeln(line);
        }
      } catch (_) {
        await _handleError(path);
      }
    }
  }
}

_handleError(String path) async {
  if (await FileSystemEntity.isDirectory(path)) {
    stderr.writeln('Error: $path is a directory');
    exitCode = 2;
  } else {
    stderr.writeln('Error: $path: Unknown error');
    exitCode = 1;
  }
}
