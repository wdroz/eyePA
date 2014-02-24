'''
Created on 24.02.2014

@author: William Droz
'''
import re
import urllib
if __name__ == '__main__':
    url = "https://github.com/wdroz/eyePA/wiki/journal-de-travail"
    page = urllib.urlopen(url).read()
    nbMinutes = 0
    for line in page.split('\n'):
        res = re.search(' - (\d\d)h(\d\d)-(\d\d)h(\d\d)<', line)
        try:
            print(res.group(0))
            debut = int(res.group(1))*60 + int(res.group(2))
            fin = int(res.group(3))*60 + int(res.group(4))
            nbMinutes = nbMinutes + (fin - debut)
            print(line)
        except:
            pass
    print('total = ' + str(nbMinutes) + ' minutes')
    print('total = ' + str(nbMinutes/60.0) + ' heures')
