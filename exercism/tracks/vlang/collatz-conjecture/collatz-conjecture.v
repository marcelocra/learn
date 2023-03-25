module main

fn helper(num int, count int) !int {
	if num <= 0 {
		return error('not less than zero')
	}

	if num == 1 {
		return count
	}

	new_count := count + 1

	if num % 2 == 0 {
		return helper(num / 2, new_count)
	}

	return helper(num * 3 + 1, new_count)
}

fn collatz(number int) !int {
	return helper(number, 0)
}


// println(collatz(12)!)
// println(collatz(-15)!)
// println(collatz(1000000)!)