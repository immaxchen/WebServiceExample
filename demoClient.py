from zeep import Client

client = Client('your-url-to/demoService.asmx?WSDL')
n = 20
result = client.service.GetFibonacciSequence(n)

print(result)
