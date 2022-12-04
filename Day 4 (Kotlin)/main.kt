    import java.io.File
    import java.io.InputStream


    fun main() {
		// create empty list of lists of Elves (pairs)
		val teams: MutableList<Team> = mutableListOf<Team>()
		
		// stream input file
        val inputStream: InputStream = File("/Volumes/Blue/Temp/input.txt").inputStream()

		// read into list of lines
        val lineList = mutableListOf<String>()
        inputStream.bufferedReader().forEachLine { lineList.add(it) } 
        
		// iterate through each line
		lineList.forEach{
			teams.add(Team(it))
		}

		println("Solution 1: " + teams.count {it.hasContainedRegion()})
		println("Solution 2: " + teams.count {it.hasOverlappingRegion()})
	}

	class Team(memberRegionsString:String){
		val member1: Elf
		val member2: Elf
		init {
			var memberRegions = memberRegionsString.split(",").toTypedArray()
			member1 = Elf(memberRegions[0])
			member2 = Elf(memberRegions[1])
		}

		fun hasContainedRegion(): Boolean {
			return member1.region.contains(member2.region) || member2.region.contains(member1.region)
		}

		fun hasOverlappingRegion(): Boolean {
			return member1.region.overlaps(member2.region) || member2.region.overlaps(member1.region)
		}
	}


	class Elf(regionString: String) {
		var region: Region
		init {
			val parts = regionString.split("-").toTypedArray()
			region = Region(parts[0].toInt(), parts[1].toInt()) 
		}
	}

	class Region(val min: Int, val max: Int) {
		
		val width:Int = Math.abs(max - min)
		
		fun overlaps(region: Region): Boolean {
			return region.min in min..max || region.max in min..max
		}

		fun contains(region: Region): Boolean {
			return region.min in min..max && region.max in min..max
		}
	}
