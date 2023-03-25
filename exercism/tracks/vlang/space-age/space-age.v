module main

fn age(seconds f64, planet string) !f64 {
	// age should return an error if the seconds is negative.
	if seconds < 0 {
		return error('Seconds cannot be negative')
	}

	// age should return the age in years rounded to the nearest second age on
	// Earth.
	earth_age := seconds / 31557600

	return match planet {
		'Earth' { earth_age }
		'Mercury' { earth_age / 0.2408467 }
		'Venus' { earth_age / 0.61519726 }
		'Mars' { earth_age / 1.8808158 }
		'Jupiter' { earth_age / 11.862615 }
		'Saturn' { earth_age / 29.447498 }
		'Uranus' { earth_age / 84.016846 }
		'Neptune' { earth_age / 164.79132 }
		else { error ('${planet} is not a valid planet') }
	}
}
