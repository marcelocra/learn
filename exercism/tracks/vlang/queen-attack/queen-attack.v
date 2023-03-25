module main

import validator

enum Direction {
	up_left
	up_right
	down_left
	down_right
	left
	right
	up
	down
}

fn recur(curr_letter_white u8, curr_number_white u8, letter_black u8, number_black u8, dir Direction) bool {
	// Current white piece is off the board.
	if validator.off_board(curr_letter_white, curr_number_white) {
		return false
	}

	// White piece moved to exact same spot as black piece. Queen can attack.
	if curr_letter_white == letter_black && curr_number_white == number_black {
		return true
	}

	// Continue moving the white piece in the given direction.
	return match dir {
		.up_left {
			recur(curr_letter_white - 1, curr_number_white + 1, letter_black, number_black,
				dir)
		}
		.up_right {
			recur(curr_letter_white + 1, curr_number_white + 1, letter_black, number_black,
				dir)
		}
		.down_left {
			recur(curr_letter_white - 1, curr_number_white - 1, letter_black, number_black,
				dir)
		}
		.down_right {
			recur(curr_letter_white + 1, curr_number_white - 1, letter_black, number_black,
				dir)
		}
		.left {
			recur(curr_letter_white - 1, curr_number_white, letter_black, number_black,
				dir)
		}
		.right {
			recur(curr_letter_white + 1, curr_number_white, letter_black, number_black,
				dir)
		}
		.up {
			recur(curr_letter_white, curr_number_white + 1, letter_black, number_black,
				dir)
		}
		.down {
			recur(curr_letter_white, curr_number_white - 1, letter_black, number_black,
				dir)
		}
	}
}

fn can_queen_attack(white string, black string) !bool {
	validator.is_valid_starting_point(white, black) or {
		return err
	}

	letter_white := white[0]
	number_white := white[1]

	letter_black := black[0]
	number_black := black[1]

	return recur(letter_white, number_white, letter_black, number_black, Direction.up_left)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.up_right)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.down_left)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.down_right)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.left)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.right)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.up)
		|| recur(letter_white, number_white, letter_black, number_black, Direction.down)
}
