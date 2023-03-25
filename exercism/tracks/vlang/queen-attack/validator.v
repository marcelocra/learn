module validator

pub fn off_board(letter u8, number u8) bool {
	return letter < u8('a'[0]) || letter > u8('h'[0]) || number < u8('1'[0]) || number > u8('8'[0])
}

pub fn is_valid_starting_point(white string, black string) !bool {
	if white.len != 2 {
		return error('${white} is not a valid square')
	}

	if black.len != 2 {
		return error('${black} is not a valid square')
	}

	if white == black {
		return error('queens on same square')
	}

	letter_white := white[0]
	number_white := white[1]

	if off_board(letter_white, number_white) {
		return error('$white is not a valid square')
	}

	letter_black := black[0]
	number_black := black[1]

	if off_board(letter_black, number_black) {
		return error('$black is not a valid square')
	}

	return true
}
