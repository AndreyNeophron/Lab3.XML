<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method='html' encoding='UTF-8'/>
<xsl:template match="mediaDatabase">
	<HTML>
		<BODY>
			<p>
				<H2>Список фільмів</H2>
			</p>
		</BODY>
		<BODY>
			<TABLE BORDER="2">
				<TR ALIGN="center">
					<TD ROWSPAN="2">
						<b>Назва</b>
					</TD>
					<TD>
						<b>Жанри</b>
					</TD>
					<TD>
						<b>Рік</b>
					</TD>
					<TD>
						<b>Країни</b>
					</TD>
					<TD>
						<b>Режисери</b>
					</TD>
					<TD>
						<b>Актори</b>
					</TD>
					<TD>
						<b>Рейтинг IMDB</b>
					</TD>
					<TD>
						<b>Рейтинг Кінопошук</b>
					</TD>
					<TD>
						<b>Час</b>
					</TD>
				</TR>
				<TR ALIGN="center">
					<TD COLSPAN="8">
						<b>Анотація</b>
					</TD>
				</TR>
				<xsl:apply-templates select="film"/>
			</TABLE>
		</BODY>
	</HTML>
</xsl:template>
<xsl:template match="film">
	<TR ALIGN="center">
		<TD ROWSPAN="2">
			<b>
				<xsl:value-of select="title"/>
			</b>
		</TD>
		<TD>
			<xsl:for-each select="genre">
				<xsl:value-of select="."/>
				<br></br>
			</xsl:for-each>
		</TD>
		<TD>
			<xsl:value-of select="year"/>
		</TD>
		<TD>
			<xsl:for-each select="country">
				<xsl:value-of select="."/>
				<br></br>
			</xsl:for-each>
		</TD>
		<TD>
			<xsl:for-each select="director">
				<xsl:value-of select="."/>
				<br></br>
			</xsl:for-each>
		</TD>
		<TD>
			<xsl:for-each select="character">
				<xsl:value-of select="."/>
				<br></br>
			</xsl:for-each>
		</TD>
		<TD>
			<xsl:value-of select="rate/@IMDB"/>
		</TD>
		<TD>
			<xsl:value-of select="rate/@kinopoisk"/>
		</TD>
		<TD>
			<xsl:value-of select="length"/>
		</TD>
	</TR>
	<TR>
		<TD COLSPAN="8">
			<xsl:value-of select="anotation"/>
		</TD>
	</TR>
</xsl:template>
</xsl:stylesheet>

