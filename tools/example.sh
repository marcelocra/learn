#!/usr/bin/env sh

asciidoctor -b manpage example.adoc && (cat example.1 | groff -T utf8 -man | nvim '+Man!')
