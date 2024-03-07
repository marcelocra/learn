import { printf, toConsole } from "./fable_modules/fable-library-js.4.14.0/String.js";

export function hello(a, b) {
    toConsole(printf("hello, %s, %s"))(a)(b);
}

