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

void P3()//���η� ����� ������
{
	float tx = fract(v_TexPos.x * 3);
	float ty = (2 - floor(v_TexPos.x * 3)) / 3 + v_TexPos.y / 3;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P4() //���η� �����
{
	float tx = fract(v_TexPos.x * 3);
	float ty = floor(v_TexPos.x * 3) / 3 + v_TexPos.y / 3;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P5() //R,G,B ���Ʒ� ���� �ٲٱ�
{
	float tx = v_TexPos.x;
	float ty = (floor(v_TexPos.y * 3) * -2 + 2) / 3 + v_TexPos.y;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

void P6() //������ 0.5 ���ϰ� �Ʒ��� �״��
{
	float padding = 0.5 + u_Time;
	float countX = 2;
	float countY = 2;

	float tx = (fract(v_TexPos.x) * countX) + (padding * (1 - floor(v_TexPos.y * countY)));
	float ty = v_TexPos.y * countY;
	vec2 newTexPos = vec2(tx, ty);
	FragColor = texture(u_Texture, newTexPos);
}

//������ �״�� �������� 0.5 ���ϱ� (��� �������� �þ��, ��� �������� �����̳Ŀ� ���� x�� �ǵ帱�� y�� �ǵ帱���� ������.)
//x���� �������� y ���� ������ ���� �޶������ϸ� float tx �� �ٲ����.
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
