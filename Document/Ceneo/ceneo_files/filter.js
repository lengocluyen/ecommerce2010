function filter()
{    
    var categoryId = getCategoryId();    
    var filters = getFilters();	
    var geo = getGeo();    
    var priceMin = getPriceMin();
    var priceMax = getPriceMax();
    var seachText = getSearchText();
   
   $.getJSON("geturl", {categoryId: categoryId, filters: filters, geo: geo, priceMin: priceMin, priceMax: priceMax, searchText: seachText},  function(json){ window.location=json; });
   
   return false;
}

function getCategoryId()
{
    var categoryId = document.getElementById('category-id');
    if(categoryId != null)
    {
        return categoryId.value;
    }
    return "";
}

function getFilters()
{
    var filters = [];
    
    for(var i=0;i<10;i++)
    {
        var parentId = 'js-tip-form-body-filters-' + i;
        var inputPrefix = 'js-form-body-filters-' + i + '-';
        var parent = document.getElementById(parentId);
        var singleFilter = [];
        filters[i] = singleFilter;
        
        if(parent != null)
        {
            forEach(parent.getElementsByTagName('input'), function()
	        {
	            if(this.id && this.checked)
	            {
	                   var name = this.id;
	                   if(name.length > 0)
	                   {
	                       name = name.replace(inputPrefix, '');
	                       singleFilter[singleFilter.length] = name;
	                   }
	            }		
	        });
	    }
	}
	
	return filters;
}

function getGeo()
{
    var geo = document.getElementById('js-tip-form-body-filters-geo');
    if(geo == null)
    {
        return "";
    }
    
    var geoValue = null;
    forEach(geo.getElementsByTagName('input'), function() {
	    if (this.id && this.checked) {
	        geoValue = this.id.replace('js-form-body-filters-geo-', '');
	    }
	});
	
	if(geoValue==null)
	{
	    return "";
	}
	
	return geoValue;
}

function getPriceMin()
{
    var priceMin = document.getElementById('form-body-filters-price-min');
    if(priceMin != null)
    {
        return priceMin.value;
    }
    return "";
}

function getPriceMax()
{
    var priceMax = document.getElementById('form-body-filters-price-max');
    if(priceMax!=null)
    {
        return priceMax.value;
    }
    return "";
}

function getSearchText()
{
    var seachText = document.getElementById('search-query');
    if(seachText!=null)
    {
        return seachText.value;
    }
    return "";
}

function clearFilter(x)
{
    ceneoFilters.erase(x);
    ceneoFilters.toogle(x);
    ceneoFilters.toogle(x);
    return filter();
}