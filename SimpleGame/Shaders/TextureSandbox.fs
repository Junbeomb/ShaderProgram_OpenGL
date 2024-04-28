#version 330

layout(location=0) out vec4 FragColor;

uniform sampler2D u_Texture;
uniform sampler2D u_NumberTexture[10];
uniform sampler2D u_NumbersTexture;
uniform float u_Time;

in vec2 v_TexPos;

void P1()
{
	float tx = v_TexPos.x;
	float ty = v_TexPos.y;
	vec2 newTexPos = vec2(tx,ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P2()
{
	float tx = v_TexPos.x;
	float ty = 1-fract(abs(v_TexPos.y-0.5) * 2);
	vec2 newTexPos = vec2(tx,ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P3()//세로로 만들기 뒤집기
{
	float tx = fract(v_TexPos.x * 3);
	float ty = (2 - floor(v_TexPos.x * 3)) / 3 + v_TexPos.y / 3;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P4() //세로로 만들기
{
	float tx = fract(v_TexPos.x * 3);
	float ty = floor(v_TexPos.x * 3) / 3 + v_TexPos.y / 3;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P5() //R,G,B 위아래 순서 바꾸기
{
	float tx = v_TexPos.x;
	float ty = (floor(v_TexPos.y * 3) * -2 + 2) / 3 + v_TexPos.y;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P6() //위에는 0.5 더하고 아래는 그대로
{
	float padding = 0.5 + u_Time;
	float countX = 2;
	float countY = 2;

	float tx = (fract(v_TexPos.x) * countX) + (padding * (1 - floor(v_TexPos.y * countY)));
	float ty = v_TexPos.y * countY;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

//왼쪽은 그대로 오른쪽은 0.5 더하기 (어느 방향으로 늘어나냐, 어느 방향으로 움직이냐에 따라서 x를 건드릴지 y를 건드릴지가 결정됨.)
//x축의 방향으로 y 값의 정도에 따라서 달라진다하면 float tx 를 바꿔야함.
void P7() 
{
	float padding = 0.5 + u_Time;
	float countX = 2;
	float countY = 2;

	float tx = v_TexPos.x * countX;
	float ty = (v_TexPos.y * countY) + padding * (floor(v_TexPos.x * 2));
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P8()
{
	vec2 newTexPos;
	float tx = v_TexPos.x;
	float ty = v_TexPos.y;
	newTexPos = vec2(tx, ty);

	int texID = int(u_Time)%10;

	FragColor = texture(u_NumberTexture[0], newTexPos);
}

void P9()
{
	vec2 newTexPos;
	float xResol = 5;
	float yResol = 2;
	float id = int(u_Time)%10;

	float indexX = float(int(id)%int(xResol));
	float indexY = floor(id / xResol);

	float tx = v_TexPos.x / xResol + indexX * (1 / xResol);
	float ty = v_TexPos.y / yResol + indexY * (1 / yResol);
	newTexPos = vec2(tx, ty);

	FragColor = texture(u_NumbersTexture, newTexPos);
}

void main()
{
	P9();
}
