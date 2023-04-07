#!/usr/bin/env bash

v main.v -o mainV
rustc main.rs --crate-type bin -o mainRust
go build -o mainGo main.go

echo "V"
time ./mainV

echo "Rust"
time ./mainRust

echo "Go"
time ./mainGo
