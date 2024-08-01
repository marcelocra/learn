#!/usr/bin/env -S dart run

import "dart:core";
import "dart:io";

void main(List<String> args) async {
  exitCode = 0; // Presume succees.

  switch (args) {
    case [var cmd, ...var cmdArgs]:
      print('cmd: $cmd, args: $cmdArgs');

      try {
        final process = await Process.start(cmd, cmdArgs);
        await stdout.addStream(process.stdout);
        await stderr.addStream(process.stderr);
        exitCode = await process.exitCode;
      } catch (e) {
        // print('Error: $e');
        exitCode = 1;
      }
      break;
    default:
      print('Unsupported case');
      exitCode = 1;
      break;
  }
}
