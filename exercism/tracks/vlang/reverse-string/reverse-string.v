module main

// reverse_string returns a given string in reverse order
fn reverse_string(str string) string {
	return str.reverse()
}

// TODO: keep going.
fn reverse_string_2(str string) string {
	if str.len == 0 || str.len == 1 {
		return str
	}

	for i, _ in str {
		if i > (str.len / 2) {
			break
		}

		fst := str[i]
		lst := str[str.len - i - 1]

		str[i] = lst
		str[str.len - i - 1] = fst
	}

	return str
}