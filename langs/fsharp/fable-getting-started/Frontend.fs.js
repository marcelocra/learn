import { printf, toConsole } from "./fable_modules/fable-library-js.4.14.0/String.js";

export const str = "Hello, world! hello people";

toConsole(printf("%s"))(str);

export const div = document.createElement("div");

div.innerHTML = str;

document.body.appendChild(div);

