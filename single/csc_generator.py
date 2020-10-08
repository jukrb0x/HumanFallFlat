import glob

# compiling Asssembly-Charp.dll should not import itself. So make a list to ignore them.
# 编译Asssembly-Charp.dll不应该引入自己。所以定义一个list来忽略这些。
ignore_list = ['../reference/osx/Assembly-CSharp.dll']

# command head
# 命令头
command = 'csc -t:library -out:./Assembly-CSharp.dll -errorlog:./errorlog.log -nostdlib -noconfig '

# iterate reference folder
# 遍历引入文件夹
for path in glob.glob('../reference/osx/*'):
    # ignore which should be ignored
    # 忽略该忽略的
    if(path in ignore_list):
        continue
    # add references
    # 添加引入
    command += '-r:' + path + ' '
# command tail
# 命令尾
command += ' ./Assembly-CSharp.cs'
# output to a file and print
# 输出到文件和控制台
with open('./complie_code.txt', 'w') as wf:
    wf.write(command)
print(command)