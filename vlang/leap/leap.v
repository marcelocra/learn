module main

fn is_evently_divisible(year int) bool {
	return year % 4 == 0
}

// is_leap_year returns true if the given year is a leap year in the Gregorian calendar
fn is_leap_year(year int) bool {
	// Not evenly divisible by 4? Not leap.
	if year % 4 != 0 {
		return false
	}

	// Evenly divisible by 4 but not by 100? Leap year.
	if year % 100 != 0 {
		return true
	}

	// Evenly divisible by 4 and by 100, but not by 400? Not a leap year.
	if year % 400 != 0 {
		return false
	}

	// Evenly divisible by 4, 100 and 400? Leap year.
	return true
}