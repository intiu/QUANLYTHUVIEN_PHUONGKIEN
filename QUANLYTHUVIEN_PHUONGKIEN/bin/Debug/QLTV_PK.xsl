<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <meta charset="utf-8"></meta>
        <title>QUẢN LÝ THƯ VIỆN</title>
      </head>
      <body>
        <h1 style="color:blue" align="left">SÁCH</h1>
        <table  boder="1">
          <tr>
            <th>MaSACH</th>
            <th>MaPT</th>
            <th>MaPM</th>
            <th>TenSach</th>
            <th>TacGia</th>
            <th>TenLoaiSach</th>
            <th>NgonNgu</th>
            <th>SLNhap</th>
            <th>VITRIDATSACH</th>
            <th>NhaXuatBan</th>
            <th>TinhTrang</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/SACH">
            <tr>
              <td>
                <xsl:value-of select="MaSACH"/>
              </td>
              <td>
                <xsl:value-of select="MaPT"/>
              </td>
              <td>
                <xsl:value-of select="MaPM"/>
              </td>
              <td>
                <xsl:value-of select="TenSach"/>
              </td>
              <td>
                <xsl:value-of select="TacGia"/>
              </td>
              <td>
                <xsl:value-of select="TenLoaiSach"/>
              </td>
              <td>
                <xsl:value-of select="NgonNgu"/>
              </td>
              <td>
                <xsl:value-of select="SLNhap"/>
              </td>
              <td>
                <xsl:value-of select="VITRIDATSACH"/>
              </td>
              <td>
                <xsl:value-of select="NhaXuatBan"/>
              </td>
              <td>
                <xsl:value-of select="TinhTrang"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">NHÂN VIÊN</h1>
        <table boder="1">
          <tr>
            <th>MaNV</th>
            <th>TenNV</th>
            <th>NgaySinhNV</th>
            <th>DiaChiNV</th>
            <th>SDTNV</th>
            <th>LuongNV</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/NHANVIEN">
            <tr>
              <td>
                <xsl:value-of select="MaNV"/>
              </td>
              <td>
                <xsl:value-of select="TenNV"/>
              </td>
              <td>
                <xsl:value-of select="NgaySinhNV"/>
              </td>
              <td>
                <xsl:value-of select="DiaChiNV"/>
              </td>
              <td>
                <xsl:value-of select="SDTNV"/>
              </td>
              <td>
                <xsl:value-of select="LuongNV"/>
              </td>
            </tr>

          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">NHÀ XUẤT BẢN</h1>
        <table boder="1">
          <tr>
            <th>MaNXB</th>
            <th>TenNXB</th>
            <th>DiaChiNXB</th>
            <th>EmailNXB</th>
            <th>SDTNXB</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/NHAXUATBAN">
            <tr>
              <td>
                <xsl:value-of select="MaNXB"/>
              </td>
              <td>
                <xsl:value-of select="TenNXB"/>
              </td>
              <td>
                <xsl:value-of select="DiaChiNXB"/>
              </td>
              <td>
                <xsl:value-of select="EmailNXB"/>
              </td>
              <td>
                <xsl:value-of select="SDTNXB"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">ĐỘC GIẢ</h1>
        <table boder="1">
          <tr>
            <th>MaDG</th>
            <th>TenDG</th>
            <th>SDTDG</th>
            <th>GTDG</th>
            <th>NgaySinhDG</th>
            <th>MaTTV</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/DOCGIA">
            <tr>
              <td>
                <xsl:value-of select="MaDG"/>
              </td>
              <td>
                <xsl:value-of select="TenDG"/>
              </td>
              <td>
                <xsl:value-of select="SDTDG"/>
              </td>
              <td>
                <xsl:value-of select="GTDG"/>
              </td>
              <td>
                <xsl:value-of select="NgaySinhDG"/>
              </td>
              <td>
                <xsl:value-of select="MaTTV"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">PHIẾU THU</h1>
        <table boder="1">
          <tr>
            <th>MaPT</th>
            <th>MaSACH</th>
            <th>NgayThu</th>
            <th>GiaTienThu</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/PHIEUTHU">
            <tr>
              <td>
                <xsl:value-of select="MaPT"/>
              </td>
              <td>
                <xsl:value-of select="MaSACH"/>
              </td>
              <td>
                <xsl:value-of select="NgayThu"/>
              </td>
              <td>
                <xsl:value-of select="GiaTienThu"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">THẺ THƯ VIỆN</h1>
        <table boder="1">
          <tr>
            <th>MaTTV</th>
            <th>NgayCapTTV</th>
            <th>NgayHetHan</th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/THETHUVIEN">
            <tr>
              <td>
                <xsl:value-of select="MaTTV"/>
              </td>
              <td>
                <xsl:value-of select="NgayCapTTV"/>
              </td>
              <td>
                <xsl:value-of select="NgayHetHan"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">BÁO CÁO</h1>
        <table boder="1">
          <tr>
            <th>MaBC</th>
            <th>NgayBC</th>
            <th>TienThuduoc</th>
            <th>TongTien</th>
            <xsl:variable name="TongTien" select="number(substring(TienThuduoc,20,0)) - number(substring(LuongNV,20,0))"/>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/BAOCAO">
            <tr>
              <td>
                <xsl:value-of select="MaBC"/>
              </td>
              <td>
                <xsl:value-of select="NgayBC"/>
              </td>
              <td>
                <xsl:value-of select="TienThuduoc"/>
              </td>
              <td>
                <xsl:value-of select="TongTien"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <h1 style="color:blue" align="left">PHIẾU MƯỢN</h1>
        <table boder="1">
          <tr>
            <th>MaPM</th>
            <th>MaSACH</th>
            <th>NgayMuon</th>
            <th>NgayTra</th>
            <th>HanTra</th>
            <th>
              <xsl:variable name="ThoiGianTra" select="number(substring(HanTra,9,2)) - number(substring(NgayMuon,9,2))"/>
            </th>
          </tr>
          <xsl:for-each select="/QUANLYTHUVIEN/PHIEUMUON">
            <tr>
              <td>
                <xsl:value-of select="MaPM"/>
              </td>
              <td>
                <xsl:value-of select="MaSACH"/>
              </td>
              <td>
                <xsl:value-of select="NgayMuon"/>
              </td>
              <td>
                <xsl:value-of select="NgayTra"/>
              </td>
              <td>
                <xsl:value-of select="HanTra"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>