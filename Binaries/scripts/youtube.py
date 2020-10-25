import pafy
import os
import sys
import json

arguments = sys.argv

path = os.path.dirname(os.path.realpath(sys.argv[0]))

def formatDictionary(dictionary, stream_list):
	data_list = []
	for x in dictionary:
		 data_list.append(formatFileInfoString(dictionary[x], stream_list[int(x)-1]))
	return data_list
def formatFileInfoString(string, stream):
	intermediateColon = string.split(':')[1]
	interdict = {
	"StreamType": string.split(':')[0],
	"FileFormat": intermediateColon.split('@')[0],
	"Resolution": intermediateColon.split('@')[1],
	"Link": stream.url
	}
	return interdict

url = arguments[1]

k = 0
while (k < 10):
	print("Retrieving youtube video data: Attempt " + str(k+1))
	try:
		video = pafy.new(url)
		break
	except(OSError):
		k += 1

if(k >= 10):
	print("Couldn't retrieve youtube video!")
	sys.exit(2)
	
print("Retrieving streams.")
streams = video.allstreams
print("Retrieving streams done")

print("Format dictionaries...")
streams_dict = {str(i+1): str(streams[i]) for i in range(0, len(streams), 1)}
streams_list = formatDictionary(streams_dict, streams)

video_dict = {
"Name": video.title,
"Uploader": video.author,
"Duration": video.duration,
"Length": video.length,
"Streams": streams_list, 
}
print("Finished dictionaries!")

print("Writing json...")
video_json = json.dumps(video_dict)

json_file = open(path+"/output.json", "w")
json_file.write(video_json)
json_file.close()
print("Finished writing json!")

print("Success!")
sys.exit(0)