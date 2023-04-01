import pyvisa as visa

rm = visa.ResourceManager()
for re in rm.list_opened_resources() :
    re.close()

for re in rm.list_resources():
    if re.startswith('USB0::0x1AB1::'):
        print(re)
        inst = rm.open_resource(re, open_timeout=10000)
        try:
            inst.timeout = 10000
            ret = inst.query("*IDN?")
            print(ret)
            inst.close()
        except Exception as e:
            print(e)
rm.close()