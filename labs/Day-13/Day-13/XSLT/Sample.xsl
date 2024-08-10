<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
	<html>
		<body>
			<h2>My Books</h2>
			<table>
				<tr>
					<th>Book Name</th>
					<th>Author</th>
				</tr>
				<xsl:for-each select="bookstore/book">
				<tr>
					<td>
						<xsl:value-of select="title" /></td>
						<td>.</td>
				</tr>
				</xsl:for-each>
			</table>
		</body>
	</html>
	
</xsl:template>

</xsl:stylesheet>
	
